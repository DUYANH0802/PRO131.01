using PRO131_01.Data;
using PRO131_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace PRO131_01.Forms
{
    public partial class FormBH : Form
    {
        //private List<SanPham> danhSachSP;
        //private List<(SanPham sanPham, int soLuong)> gioHang;
        private DataTable dataForGrid;
        private BindingList<GioHangItem> giohang;
        private CategoryDbContext dbContext;
        public FormBH()
        {
            InitializeComponent();
            dbContext = new CategoryDbContext();
        }

        private void FormBH_Load(object sender, EventArgs e)
        {
            giohang = new BindingList<GioHangItem>();
            dgvGioHang.DataSource = giohang;
            //gioHang = new List<(SanPham, int)>();
            LoadSanPham();
            HienThiGioHang();
        }

        private void LoadSanPham()
        {
            try
            {
                using (var db = new CategoryDbContext())
                {
                    //danhSachSP = db.SanPhams.ToList();
                    var query = (from sp in db.SanPhams
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
                    // Chuyển đổi kết quả sang DataTable để dễ dàng binding và lấy dữ liệu
                    dataForGrid = ConvertToDataTable(query);
                    dgvSanPham.DataSource = dataForGrid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
        // Hàm chuyển đổi danh sách sang DataTable
        private DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            DataTable table = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in props)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        private void ConfigureSanPhamGridColumns()
        {
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

            // Ẩn cột HinhAnh nếu không cần hiển thị
            //dgvSanPham.Columns["HinhAnh"].Visible = false;
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thêm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Lấy MaSanPham từ dòng được chọn trong dgvSanPham
            int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value);
            //// Lấy dòng được chọn
            //var selectedRow = dgvSanPham.SelectedRows[0];
            //int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value);
            //// Tìm sản phẩm trong danh sách
            //var sp = danhSachSP.FirstOrDefault(x => x.MaSanPham == maSP);

            // Tìm sản phẩm trong database
            using (var db = new CategoryDbContext())
            {
                var sp = db.SanPhams.FirstOrDefault(x => x.MaSanPham == maSP);

                if (sp != null)
                {
                    if (int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
                    {
                        if (soLuong > sp.SoLuongTonKho)
                        {
                            MessageBox.Show($"Số lượng mua vượt quá tồn kho! Chỉ còn {sp.SoLuongTonKho} sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var existingItem = giohang.FirstOrDefault(y => y.SanPham.MaSanPham == sp.MaSanPham);
                        if (existingItem != null)
                        {
                            if (existingItem.SoLuong + soLuong > sp.SoLuongTonKho)
                            {
                                MessageBox.Show($"Tổng số lượng vượt quá tồn kho! Chỉ còn {sp.SoLuongTonKho} sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            existingItem.SoLuong += soLuong;
                        }
                        else
                        {
                            giohang.Add(new GioHangItem(sp, soLuong));
                        }
                        HienThiGioHang();
                        txtSoLuong.Text = "1";
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //if (dgvSanPham.SelectedRows.Count > 0)
            //{
            //    int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value);
            //    var sp = danhSachSP.FirstOrDefault(x => x.MaSanPham == maSP);

            //    if (sp != null)
            //    {
            //        if (int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
            //        {
            //            if (soLuong > sp.SoLuongTonKho)
            //            {
            //                MessageBox.Show("Số lượng mua vượt quá tồn kho!");
            //                return;
            //            }

            //            var item = gioHang.FirstOrDefault(g => g.sanPham.MaSanPham == sp.MaSanPham);
            //            if (item.sanPham != null)
            //            {
            //                gioHang.Remove(item);
            //                gioHang.Add((sp, item.soLuong + soLuong));
            //            }
            //            else
            //            {
            //                gioHang.Add((sp, soLuong));
            //            }

            //            HienThiGioHang();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Nhập số lượng hợp lệ!");
            //        }
            //    }
            //}
        }

        private void btnXoaGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                // Lấy MaSanPham từ dòng được chọn
                int maSP = Convert.ToInt32(dgvGioHang.SelectedRows[0].Cells["MaSanPham"].Value);

                // Tìm item trong giỏ hàng theo MaSanPham
                var itemToRemove = giohang.FirstOrDefault(item => item.SanPham.MaSanPham == maSP);

                if (itemToRemove != null)
                {
                    giohang.Remove(itemToRemove);
                    HienThiGioHang();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa khỏi giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //int maSP = Convert.ToInt32(dgvGioHang.SelectedRows[0].Cells["MaSanPham"].Value);
            //var item = gioHang.FirstOrDefault(g => g.sanPham.MaSanPham == maSP);
            //if (item.sanPham != null)
            //{
            //    gioHang.Remove(item);
            //    HienThiGioHang();
            //}            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (giohang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //using (var db = new CategoryDbContext())
            //{
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate số điện thoại
            if (!ValidateSoDienThoai(sdt))
            {
                txtSDT.Focus();
                return;
            }

            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Xử lý khách hàng
                        KhachHang khach = null;
                        var khachExist = dbContext.KhachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);

                        if (khachExist != null)
                        {
                            // Nếu số điện thoại đã tồn tại, kiểm tra tên khách hàng
                            if (khachExist.TenKhachHang != tenKH)
                            {
                                var result = MessageBox.Show($"Số điện thoại {sdt} đã tồn tại với tên '{khachExist.TenKhachHang}'. Bạn có muốn cập nhật tên khách hàng thành '{tenKH}'?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    khachExist.TenKhachHang = tenKH;
                                    dbContext.SaveChanges();
                                }
                            }
                            khach = khachExist;
                        }
                        else
                        {
                            // Tạo khách hàng mới
                            int newMaKH = dbContext.KhachHangs.Any() ? dbContext.KhachHangs.Max(k => k.MaKhachHang) + 1 : 1;
                            khach = new KhachHang
                            {
                                MaKhachHang = newMaKH,
                                TenKhachHang = tenKH,
                                SoDienThoai = sdt
                            };
                            dbContext.KhachHangs.Add(khach);
                            dbContext.SaveChanges();
                        }

                        // Tạo hóa đơn
                        decimal tongTien = giohang.Sum(item => (item.SanPham.GiaBan ?? 0) * item.SoLuong);
                        int newMaHD = dbContext.HoaDons.Any() ? dbContext.HoaDons.Max(h => h.MaHoaDon) + 1 : 1;

                        var hoaDon = new HoaDon
                        {
                            MaHoaDon = newMaHD,
                            MaKhachHang = khach.MaKhachHang,
                            MaNhanVien = 1, // Cần thay bằng mã nhân viên thực tế                            
                            TongTien = tongTien,
                            TrangThai = "Đã thanh toán"
                        };
                        dbContext.HoaDons.Add(hoaDon);

                        // Xử lý chi tiết hóa đơn và cập nhật tồn kho
                        foreach (var item in giohang)
                        {
                            var spTrongDb = dbContext.SanPhams.FirstOrDefault(sp => sp.MaSanPham == item.SanPham.MaSanPham);
                            if (spTrongDb == null)
                            {
                                if (spTrongDb.SoLuongTonKho < item.SoLuong)
                                {
                                    throw new Exception($"Sản phẩm {spTrongDb.TenSanPham} không đủ trong kho!");
                                }
                                spTrongDb.SoLuongTonKho -= item.SoLuong;

                                var cthd = new HoaDonChiTiet
                                {
                                    MaHoaDon = hoaDon.MaHoaDon,
                                    MaSanPham = item.SanPham.MaSanPham,
                                    SoLuong = item.SoLuong,
                                    DonGia = item.SanPham.GiaBan
                                };
                                dbContext.HoaDonChiTiets.Add(cthd);
                            }
                        }
                        dbContext.SaveChanges();
                        transaction.Commit();

                        // Hiển thị thông báo thành công
                        string message = $"Thanh toán thành công!\n\nMã hóa đơn: {hoaDon.MaHoaDon}\nKhách hàng: {khach.TenKhachHang}\nTổng tiền: {tongTien:N0} VNĐ";
                        MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset form
                        giohang.Clear();
                        HienThiGioHang();
                        LoadSanPham();
                        txtTenKH.Clear();
                        txtSDT.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Lỗi trong quá trình thanh toán: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //var khach = db.KhachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);
        //if (khach == null)
        //{
        //    int newMaKH = (db.KhachHangs.Any() ? db.KhachHangs.Max(k => k.MaKhachHang) : 0) + 1;
        //    khach = new KhachHang
        //    {
        //        MaKhachHang = newMaKH,
        //        TenKhachHang = tenKH,
        //        SoDienThoai = sdt
        //    };
        //    db.KhachHangs.Add(khach);
        //    db.SaveChanges();
        //}


        //    decimal tongTien = gioHang.Sum(sp => (sp.sanPham.GiaBan ?? 0) * sp.soLuong);
        //    int newMaHD = (db.HoaDons.Any() ? db.HoaDons.Max(h => h.MaHoaDon) : 0) + 1;

        //    var hoaDon = new HoaDon
        //    {
        //        MaHoaDon = newMaHD,
        //        MaKhachHang = khach.MaKhachHang,
        //        MaNhanVien = 1,
        //        NgayLap = DateOnly.FromDateTime(DateTime.Now),
        //        TongTien = tongTien,
        //        TrangThai = "Đã thanh toán"
        //    };

        //    db.HoaDons.Add(hoaDon);
        //    db.SaveChanges();

        //    foreach (var item in gioHang)
        //    {
        //        var spTrongDb = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == item.sanPham.MaSanPham);
        //        if (spTrongDb != null)
        //        {
        //            if (spTrongDb.SoLuongTonKho < item.soLuong)
        //            {
        //                MessageBox.Show($"Sản phẩm {spTrongDb.TenSanPham} không đủ tồn kho!");
        //                return;
        //            }

        //            spTrongDb.SoLuongTonKho -= item.soLuong;

        //            var cthd = new HoaDonChiTiet
        //            {
        //                MaHoaDon = hoaDon.MaHoaDon,
        //                MaSanPham = item.sanPham.MaSanPham,
        //                SoLuong = item.soLuong,
        //                DonGia = item.sanPham.GiaBan
        //            };

        //            db.HoaDonChiTiets.Add(cthd);
        //        }
        //    }

        //    db.SaveChanges();

        //    MessageBox.Show($"Thanh toán thành công và lưu hóa đơn!\nMã HD: {hoaDon.MaHoaDon}, Khách: {khach.TenKhachHang}, Tổng tiền: {tongTien:N0} VNĐ");
        //    gioHang.Clear();
        //    HienThiGioHang();
        //    LoadSanPham();
        //}
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiGioHang()
        {
            int stt = 1;
            dgvGioHang.DataSource = giohang.Select(g => new
            {
                STT = stt++,
                MaSanPham = g.SanPham.MaSanPham,
                TenSanPham = g.SanPham.TenSanPham,
                SoLuong = g.SoLuong,
                Gia = $"{g.SanPham.GiaBan:N0} VNĐ",
                ThanhTien = $"{(g.SanPham.GiaBan ?? 0) * g.SoLuong:N0} VNĐ"
            }).ToList();

            dgvGioHang.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvGioHang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvGioHang.Columns["Gia"].HeaderText = "Giá";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";

            // Sắp xếp thứ tự các cột theo ý muốn
            dgvGioHang.Columns["STT"].DisplayIndex = 0;          // Cột 1
            dgvGioHang.Columns["MaSanPham"].DisplayIndex = 1;    // Cột 2
            dgvGioHang.Columns["TenSanPham"].DisplayIndex = 2;   // Cột 3
            dgvGioHang.Columns["SoLuong"].DisplayIndex = 3;      // Cột 4
            dgvGioHang.Columns["Gia"].DisplayIndex = 4;          // Cột 5
            dgvGioHang.Columns["ThanhTien"].DisplayIndex = 5;    // Cột 6

            // Ẩn cột MaSanPham nếu không muốn hiển thị
            // dgvGioHang.Columns["MaSanPham"].Visible = false;

            //lblTongTien.Text = $"Tổng tiền: {giohang.Sum(sp => (sp.sanPham.GiaBan ?? 0) * sp.soLuong):N0} VNĐ";
            lblTongTien.Text = $"Tổng tiền: {giohang.Sum(item => (item.SanPham.GiaBan ?? 0) * item.SoLuong):N0} VNĐ";
        }
        //private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvSanPham.SelectedRows.Count > 0)
        //    {
        //        // Lấy MaSanPham từ dòng được chọn
        //        int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value);

        //        // Tìm sản phẩm trong database để hiển thị tồn kho
        //        using (var db = new CategoryDbContext())
        //        {
        //            var sp = db.SanPhams.FirstOrDefault(x => x.MaSanPham == maSP);
        //            if (sp != null)
        //            {
        //                lblTonKho.Text = $"Tồn kho: {sp.SoLuongTonKho}";
        //            }
        //        }
        //    }
        //}
        private void FormBH_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
        }
        private bool ValidateSoDienThoai(string sdt)
        {
            // Kiểm tra không được trống
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra độ dài (10-11 số cho Việt Nam)
            if (sdt.Length < 10 || sdt.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải có 10-11 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra chỉ chứa số
            if (!sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số đầu tiên phải là 0
            if (!sdt.StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số, phím backspace và phím delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            // Tự động thêm dấu cách sau mỗi 3-4 số để dễ đọc
            string sdt = txtSDT.Text.Replace(" ", "");

            if (sdt.Length > 10)
            {
                sdt = sdt.Substring(0, 10);
            }

            if (sdt.Length > 0)
            {
                string formatted = sdt;
                if (sdt.Length > 4)
                {
                    formatted = $"{sdt.Substring(0, 4)} {sdt.Substring(4)}";
                }
                if (sdt.Length > 7)
                {
                    formatted = $"{sdt.Substring(0, 4)} {sdt.Substring(4, 3)} {sdt.Substring(7)}";
                }

                if (formatted != txtSDT.Text)
                {
                    txtSDT.Text = formatted;
                    txtSDT.SelectionStart = txtSDT.Text.Length;
                }
            }
        }
    }
}
