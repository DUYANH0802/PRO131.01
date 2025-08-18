using PRO131_01.Data;
using PRO131_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PRO131_01.Forms
{
    public partial class FormBH : Form
    {
        private List<SanPham> danhSachSP;
        private List<(SanPham sanPham, int soLuong)> gioHang;

        public FormBH()
        {
            InitializeComponent();
        }

        private void FormBH_Load(object sender, EventArgs e)
        {
            gioHang = new List<(SanPham, int)>();
            LoadSanPham();
            HienThiGioHang();
        }

        private void LoadSanPham()
        {
            using (var db = new CategoryDbContext())
            {
                danhSachSP = db.SanPhams.ToList(); 
            }

            dgvSanPham.DataSource = danhSachSP.Select(sp => new
            {
                sp.MaSanPham,
                sp.TenSanPham,
                sp.MoTa,
                sp.GiaBan,
                sp.SoLuongTonKho,
                sp.HinhAnh,
                sp.MaLoaiSanPham,
                sp.MaNhaCungCap
            }).ToList();
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvSanPham.Columns["SoLuongTonKho"].HeaderText = "Số lượng tồn";
            dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            dgvSanPham.Columns["MaLoaiSanPham"].HeaderText = "Loại sản phẩm";
            dgvSanPham.Columns["MaNhaCungCap"].HeaderText = "Nhà cung cấp";
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value);
                var sp = danhSachSP.FirstOrDefault(x => x.MaSanPham == maSP);

                if (sp != null)
                {
                    if (int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
                    {
                        if (soLuong > sp.SoLuongTonKho)
                        {
                            MessageBox.Show("Số lượng mua vượt quá tồn kho!");
                            return;
                        }

                        var item = gioHang.FirstOrDefault(g => g.sanPham.MaSanPham == sp.MaSanPham);
                        if (item.sanPham != null)
                        {
                            gioHang.Remove(item);
                            gioHang.Add((sp, item.soLuong + soLuong));
                        }
                        else
                        {
                            gioHang.Add((sp, soLuong));
                        }

                        HienThiGioHang();
                    }
                    else
                    {
                        MessageBox.Show("Nhập số lượng hợp lệ!");
                    }
                }
            }
        }

        private void btnXoaGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                int maSP = Convert.ToInt32(dgvGioHang.SelectedRows[0].Cells["MaSanPham"].Value);
                var item = gioHang.FirstOrDefault(g => g.sanPham.MaSanPham == maSP);
                if (item.sanPham != null)
                {
                    gioHang.Remove(item);
                    HienThiGioHang();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!");
                return;
            }

            using (var db = new CategoryDbContext())
            {
                foreach (var item in gioHang)
                {
                    var spTrongDb = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == item.sanPham.MaSanPham);
                    if (spTrongDb != null)
                    {
                        if (spTrongDb.SoLuongTonKho < item.soLuong)
                        {
                            MessageBox.Show($"Sản phẩm {spTrongDb.TenSanPham} không đủ tồn kho!");
                            return;
                        }
                        spTrongDb.SoLuongTonKho -= item.soLuong;
                    }
                }

                db.SaveChanges();
            }

            decimal tongTien = gioHang.Sum(sp => (sp.sanPham.GiaBan ?? 0) * sp.soLuong);
            MessageBox.Show($"Thanh toán thành công! Tổng tiền: {tongTien:N0} VNĐ");

            gioHang.Clear();
            HienThiGioHang();
            LoadSanPham(); 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiGioHang()
        {
            int stt = 1;
            dgvGioHang.DataSource = gioHang.Select(g => new
            {
                STT = stt++,
                MaSanPham = g.sanPham.MaSanPham,   
                TenSanPham = g.sanPham.TenSanPham,
                SoLuong = g.soLuong,
                Gia = $"{g.sanPham.GiaBan:N0} VNĐ",
                ThanhTien = $"{(g.sanPham.GiaBan ?? 0) * g.soLuong:N0} VNĐ"
            }).ToList();

           
            dgvGioHang.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvGioHang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvGioHang.Columns["Gia"].HeaderText = "Giá";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";

            lblTongTien.Text = $"Tổng tiền: {gioHang.Sum(sp => (sp.sanPham.GiaBan ?? 0) * sp.soLuong):N0} VNĐ";
        }
    }
}
