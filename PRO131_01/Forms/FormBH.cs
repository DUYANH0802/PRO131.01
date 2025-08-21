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
                var dataForGrid = (from sp in db.SanPhams
                                  join ncc in db.NhaCungCaps on sp.MaNhaCungCap equals ncc.MaNhaCungCap into nccGroup
                                  from ncc in nccGroup.DefaultIfEmpty()
                                  join spct in db.SanPhamChiTiets on sp.MaLoaiSanPham equals spct.MaSanPhamChiTiet into spctGroup
                                  from spct in spctGroup.DefaultIfEmpty()
                                  select new
                                  {
                                      sp.MaSanPham,
                                      sp.TenSanPham,
                                      sp.GiaBan,
                                      sp.SoLuongTonKho,
                                      sp.HinhAnh,
                                      TenLoaiSanPham = spct != null ? spct.TenSanPhamChiTiet : "",
                                      KichThuoc = spct != null ? spct.KichThuoc : "",
                                      MauSac = spct != null ? spct.MauSac : "",
                                      TenNhaCungCap = ncc != null ? ncc.TenNhaCungCap : "",                                      
                                      sp.MoTa
                                  }).ToList();
                dgvSanPham.DataSource = dataForGrid;
            }

            //dgvSanPham.DataSource = danhSachSP.Select(sp => new
            //{
            //    sp.MaSanPham,
            //    sp.TenSanPham,
            //    sp.MoTa,
            //    sp.GiaBan,
            //    sp.SoLuongTonKho,
            //    sp.HinhAnh,
            //    sp.MaLoaiSanPham,
            //    sp.MaNhaCungCap
            //}).ToList();
            //dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            //dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            //dgvSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            //dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            //dgvSanPham.Columns["SoLuongTonKho"].HeaderText = "Số lượng tồn";
            //dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            //dgvSanPham.Columns["MaLoaiSanPham"].HeaderText = "Loại sản phẩm";
            //dgvSanPham.Columns["MaNhaCungCap"].HeaderText = "Nhà cung cấp";

            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã SP";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvSanPham.Columns["SoLuongTonKho"].HeaderText = "Tồn kho";
            dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            dgvSanPham.Columns["TenLoaiSanPham"].HeaderText = "Loại SP";
            dgvSanPham.Columns["KichThuoc"].HeaderText = "Kích thước";
            dgvSanPham.Columns["MauSac"].HeaderText = "Màu sắc";
            dgvSanPham.Columns["TenNhaCungCap"].HeaderText = "Nhà cung cấp";
            dgvSanPham.Columns["MoTa"].HeaderText = "Mô tả";
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
                
                string tenKH = txtTenKH.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                if (string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại khách hàng!");
                    return;
                }

                
                var khach = db.KhachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);
                if (khach == null)
                {
                    int newMaKH = (db.KhachHangs.Any() ? db.KhachHangs.Max(k => k.MaKhachHang) : 0) + 1;
                    khach = new KhachHang
                    {
                        MaKhachHang = newMaKH,
                        TenKhachHang = tenKH,
                        SoDienThoai = sdt
                    };
                    db.KhachHangs.Add(khach);
                    db.SaveChanges();
                }

                
                decimal tongTien = gioHang.Sum(sp => (sp.sanPham.GiaBan ?? 0) * sp.soLuong);
                int newMaHD = (db.HoaDons.Any() ? db.HoaDons.Max(h => h.MaHoaDon) : 0) + 1;

                var hoaDon = new HoaDon
                {
                    MaHoaDon = newMaHD,
                    MaKhachHang = khach.MaKhachHang,
                    MaNhanVien = 1, 
                    NgayLap = DateOnly.FromDateTime(DateTime.Now),
                    TongTien = tongTien,
                    TrangThai = "Đã thanh toán"
                };

                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
               
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

                        var cthd = new HoaDonChiTiet
                        {
                            MaHoaDon = hoaDon.MaHoaDon,
                            MaSanPham = item.sanPham.MaSanPham,
                            SoLuong = item.soLuong,
                            DonGia = item.sanPham.GiaBan
                        };

                        db.HoaDonChiTiets.Add(cthd);
                    }
                }

                db.SaveChanges();
                
                MessageBox.Show($"Thanh toán thành công và lưu hóa đơn!\nMã HD: {hoaDon.MaHoaDon}, Khách: {khach.TenKhachHang}, Tổng tiền: {tongTien:N0} VNĐ");
                gioHang.Clear();
                HienThiGioHang();
                LoadSanPham();
            }
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
