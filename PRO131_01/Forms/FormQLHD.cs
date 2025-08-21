using PRO131_01.Data;
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
    public partial class FormQLHD : Form
    {
        private HoaDon _selectedHoaDon = null;
        public FormQLHD()
        {
            InitializeComponent();
        }

        private void FormQLHD_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
        }
        private void LoadHoaDon()
        {
            using (var db = new CategoryDbContext())
            {
                var data = db.HoaDons
                             .Select(h => new
                             {
                                 h.MaHoaDon,
                                 h.NgayLap,
                                 h.TongTien,
                                 h.TrangThai,
                                 KhachHang = h.MaKhachHangNavigation != null ? h.MaKhachHangNavigation.TenKhachHang : "Khách lẻ",
                                 NhanVien = h.MaNhanVienNavigation != null ? h.MaNhanVienNavigation.HoTen : "Không rõ"
                             })
                             .ToList();

                dgvHoaDon.DataSource = data;
                dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa đơn";
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvHoaDon.Columns["KhachHang"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["NhanVien"].HeaderText = "Nhân viên";
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maHD = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value);

                using (var db = new CategoryDbContext())
                {
                    _selectedHoaDon = db.HoaDons.FirstOrDefault(h => h.MaHoaDon == maHD);

                    var chiTiet = db.HoaDonChiTiets
                                    .Where(ct => ct.MaHoaDon == maHD)
                                    .Select(ct => new
                                    {
                                        ct.MaSanPham,
                                        TenSanPham = ct.MaSanPhamNavigation.TenSanPham,
                                        ct.SoLuong,
                                        ct.DonGia,
                                        ThanhTien = (ct.SoLuong ?? 0) * (ct.DonGia ?? 0)
                                    })
                                    .ToList();

                    dgvChiTietHD.DataSource = chiTiet;
                    dgvChiTietHD.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                    dgvChiTietHD.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                    dgvChiTietHD.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvChiTietHD.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvChiTietHD.Columns["ThanhTien"].HeaderText = "Thành tiền";
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
            dgvChiTietHD.DataSource = null;
            _selectedHoaDon = null;
        }
    }
}
