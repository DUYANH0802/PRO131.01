using PRO131_01.Data;
using PRO131_01.Models;
using PRO131_01.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRO131_01.Repositories;

namespace PRO131_01.Forms
{
    public partial class FormQLHD : Form
    {
        private readonly HoaDonRepository _repo;
        private HoaDon _selectedHoaDon = null;

        public FormQLHD()
        {
            InitializeComponent();
            string connStr = @"Data Source=NGUYENDUYANH\SQLEXPRESS;Initial Catalog=PRO131_01;Integrated Security=True;TrustServerCertificate=True";
            _repo = new HoaDonRepository(connStr);
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpFrom.ShowCheckBox = true;

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy";
            dtpTo.ShowCheckBox = true;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedHoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa hóa đơn Mã = {_selectedHoaDon.MaHoaDon} không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (var db = new CategoryDbContext())
                {
                    try
                    {
                        // Lấy lại hóa đơn từ DbContext
                        var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaHoaDon == _selectedHoaDon.MaHoaDon);
                        if (hoaDon != null)
                        {
                            // Xóa chi tiết hóa đơn trước
                            var chiTiets = db.HoaDonChiTiets.Where(ct => ct.MaHoaDon == hoaDon.MaHoaDon).ToList();
                            if (chiTiets.Any())
                            {
                                db.HoaDonChiTiets.RemoveRange(chiTiets);
                            }

                            // Xóa hóa đơn
                            db.HoaDons.Remove(hoaDon);

                            db.SaveChanges();

                            MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh lại danh sách
                            LoadHoaDon();
                            dgvChiTietHD.DataSource = null;
                            _selectedHoaDon = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateOnly? from = dtpFrom.Checked ? DateOnly.FromDateTime(dtpFrom.Value.Date) : (DateOnly?)null;
            DateOnly? to = dtpTo.Checked ? DateOnly.FromDateTime(dtpTo.Value.Date) : (DateOnly?)null;

            var dt = _repo.FindByDateRange(from, to);
            dgvHoaDon.DataSource = dt;

            if (dgvHoaDon.Columns.Contains("NgayLap"))
                dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
}
