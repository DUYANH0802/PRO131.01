using AntdUI;
using PRO131_01.Models;
using PRO131_01.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PRO131_01.Forms
{
    public partial class FormQLNV : Form
    {
        GenericRepository<NhanVien> _repository;
        private NhanVien _selectedNhanVien = null;

        public FormQLNV()
        {
            InitializeComponent();
            _repository = new GenericRepository<NhanVien>();
            this.Load += FormQLNV_Load;
            LoadTable();
            SetupValidationEvents();
        }
        private void FillForm(NhanVien nv)
        {
            if (nv == null) return;

            txtMaNV.Text = nv.MaNhanVien.ToString();
            txtHoten.Text = nv.HoTen;
            txtSDT.Text = nv.Sdt;
            txtEmail.Text = nv.Email;
            txtDiachi.Text = nv.DiaChi;
            cbGioitinh.SelectedItem = nv.GioiTinh;
        }
        private void LoadTable()
        {
            var data = _repository.GetAll().ToList();

            dgvQLNV.Columns.Clear();
            dgvQLNV.AutoGenerateColumns = false;

            var columns = new (string Name, string Header)[] {
                (nameof(NhanVien.MaNhanVien), "Mã NV"),
                (nameof(NhanVien.HoTen), "Họ tên"),
                (nameof(NhanVien.Sdt), "SĐT"),
                (nameof(NhanVien.Email), "Email"),
                (nameof(NhanVien.DiaChi), "Địa chỉ"),
                (nameof(NhanVien.GioiTinh), "Giới tính")
            };

            foreach (var col in columns)
            {
                dgvQLNV.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = col.Name,
                    HeaderText = col.Header,
                    Name = col.Name,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }

            dgvQLNV.DataSource = data;

            dgvQLNV.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    _selectedNhanVien = dgvQLNV.Rows[e.RowIndex].DataBoundItem as NhanVien;
                    FillForm(_selectedNhanVien);
                }
            };
        }
        // Hàm tự động tạo mã nhân viên mới
        private int GenerateNewEmployeeId()
        {
            var allEmployees = _repository.GetAll();
            if (allEmployees == null || !allEmployees.Any())
            {
                return 1; // Bắt đầu từ 1 nếu chưa có nhân viên nào
            }

            return allEmployees.Max(e => e.MaNhanVien) + 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tự động tạo mã nhân viên
                int maNV = GenerateNewEmployeeId();                

                var NhanVienMoi = new NhanVien()
                {
                    MaNhanVien = maNV,
                    HoTen = txtHoten.Text.Trim(),
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim(),
                    GioiTinh = cbGioitinh.SelectedItem?.ToString()
                };
                if (_repository.GetAll().Any(k => k.MaNhanVien == maNV))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidPhoneNumber(txtSDT.Text.Trim()))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! Phải có 10-11 số và bắt đầu bằng 0.", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email phải có định dạng @gmail.com!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }


                if (maNV <= 0)
                {
                    MessageBox.Show("Mã nhân viên phải lớn hơn 0!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNV.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(NhanVienMoi.HoTen))
                {
                    MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHoten.Focus();
                    return;
                }
                if (_repository.GetAll().Any(nv => nv.MaNhanVien == maNV))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNV.Focus();
                    return;
                }
                _repository.Add(NhanVienMoi);
                LoadTable();
                ClearInputs();

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvQLNV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nhanVien = (NhanVien)dgvQLNV.CurrentRow.DataBoundItem;

                nhanVien.HoTen = txtHoten.Text.Trim();
                nhanVien.Sdt = txtSDT.Text.Trim();
                nhanVien.Email = txtEmail.Text.Trim();
                nhanVien.DiaChi = txtDiachi.Text.Trim();
                nhanVien.GioiTinh = cbGioitinh.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
                {
                    MessageBox.Show("Họ tên không được để trống", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsValidPhoneNumber(txtSDT.Text.Trim()))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! Phải có 10-11 số và bắt đầu bằng 0.", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email phải có định dạng @gmail.com!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                _repository.Update(nhanVien);
                LoadTable();

                MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa nhân viên: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvQLNV.CurrentRow == null || dgvQLNV.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa",
                              "Thông báo",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            var nhanVien = (NhanVien)dgvQLNV.CurrentRow.DataBoundItem;

            var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {nhanVien.HoTen}?",
                                             "Xác nhận xóa",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _repository.Remove(nhanVien);

                    LoadTable();

                    MessageBox.Show("Xóa nhân viên thành công!",
                                  "Thành công",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}",
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
        private void ClearInputs()
        {
            txtMaNV.Text = "";
            txtHoten.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiachi.Text = "";
            cbGioitinh.SelectedIndex = -1;
            txtMaNV.Focus();
        }
        private void FormQLNV_Load(object sender, EventArgs e)
        {
            cbGioitinh.Items.Clear();
            cbGioitinh.Items.Add("Nam");
            cbGioitinh.Items.Add("Nữ");
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void SetupValidationEvents()
        {
            // Sự kiện validate số điện thoại (chỉ cho nhập số)
            txtSDT.KeyPress += txtSDT_KeyPress;
            txtSDT.Leave += txtSDT_Leave;

            // Sự kiện validate email
            txtEmail.Leave += txtEmail_Leave;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số, phím backspace và control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSDT.Text) && !IsValidPhoneNumber(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải có 10-11 số và bắt đầu bằng 0!", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
        }
        private bool IsValidPhoneNumber(string phone)
        {
            // Kiểm tra số điện thoại Việt Nam (10-11 số, bắt đầu bằng 0)
            return Regex.IsMatch(phone, @"^(0[3|5|7|8|9])+([0-9]{8,9})\b$");
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Kiểm tra định dạng email cơ bản
                var addr = new System.Net.Mail.MailAddress(email);

                // KIỂM TRA BẮT BUỘC PHẢI CÓ @gmail.com
                bool isGmail = email.ToLower().EndsWith("@gmail.com");

                return addr.Address == email && isGmail;
            }
            catch
            {
                return false;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email phải có định dạng @gmail.com!", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }
    }
}
