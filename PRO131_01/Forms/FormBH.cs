using PRO131_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRO131_01.Forms
{
    public partial class FormBH : Form
    {
        private List<SanPham> danhSachSP;
        private List<SanPham> gioHang;

        public FormBH()
        {
            InitializeComponent();
        }

        private void FormBH_Load(object sender, EventArgs e)
        {
            // Khởi tạo danh sách giỏ hàng
            gioHang = new List<SanPham>();

            danhSachSP = new List<SanPham>
            {
                new SanPham
{
    MaSanPham = 1,
            TenSanPham = "Nike Air Max",
            MoTa = "",
            GiaBan = 2500000,
            SoLuongTonKho = 20,
            HinhAnh = "",
            MaLoaiSanPham = 1,
            MaNhaCungCap = 1
        },
        new SanPham
        {
            MaSanPham = 2,
            TenSanPham = "Adidas Ultraboost",
            MoTa = "Giày chạy bộ êm ái",
            GiaBan = 2700000,
            SoLuongTonKho = 15,
            HinhAnh = "/images/ultraboost.jpg",
            MaLoaiSanPham = 3,
            MaNhaCungCap = 2
        },
        new SanPham
        {
            MaSanPham = 3,
            TenSanPham = "Nike ZoomX",
            MoTa = "Giày thể thao tốc độ cao",
            GiaBan = 2800000,
            SoLuongTonKho = 10,
            HinhAnh = "/images/zoomx.jpg",
            MaLoaiSanPham = 2,
            MaNhaCungCap = 1
        },
        new SanPham
        {
            MaSanPham = 4,
            TenSanPham = "Adidas NMD R1",
            MoTa = "Mẫu sneaker nổi bật",
            GiaBan = 2400000,
            SoLuongTonKho = 18,
            HinhAnh = "/images/nmdr1.jpg",
            MaLoaiSanPham = 5,
            MaNhaCungCap = 2
        }
            };

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
            HienThiGioHang();
        }

    

        

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                // Lấy mã sản phẩm từ cột MaSanPham
                int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value);

                // Tìm sản phẩm trong danhSachSP
                var sp = danhSachSP.FirstOrDefault(x => x.MaSanPham == maSP);

                if (sp != null)
                {
                    if (int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
                    {
                        for (int i = 0; i < soLuong; i++)
                        {
                            gioHang.Add(sp);
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
                int index = dgvGioHang.SelectedRows[0].Index;
                gioHang.RemoveAt(index);
                HienThiGioHang();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!");
                return;
            }

            // Trừ số lượng tồn kho
            foreach (var spTrongGio in gioHang)
            {
                var spTrongDanhSach = danhSachSP.FirstOrDefault(sp => sp.MaSanPham == spTrongGio.MaSanPham);
                if (spTrongDanhSach != null)
                {
                    spTrongDanhSach.SoLuongTonKho -= 1; // mỗi lần 1 sản phẩm
                }
            }

            decimal tongTien = gioHang.Sum(sp => sp.GiaBan ?? 0);
            MessageBox.Show($"Thanh toán thành công! Tổng tiền: {tongTien:N0} VNĐ");

            gioHang.Clear();
            HienThiGioHang();

            // Cập nhật lại bảng sản phẩm
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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HienThiGioHang()
        {
            int stt = 1;
            dgvGioHang.DataSource = gioHang.Select(sp => new
            {
                STT = stt++,
                sp.MaSanPham,
                sp.TenSanPham,
                Gia = string.Format("{0:N0} VNĐ", sp.GiaBan ?? 0) // format an toàn với null
            }).ToList();

            lblTongTien.Text = $"Tổng tiền: {gioHang.Sum(sp => sp.GiaBan ?? 0):N0} VNĐ";
        }
    }
}
