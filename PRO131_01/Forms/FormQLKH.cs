using PRO131_01.Models;
using PRO131_01.Repositories;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRO131_01.Forms
{
    public partial class FormQLKH : Form
    {
        private GenericRepository<KhachHang> _repository;
        private KhachHang _selectedKhachHang = null;

        public FormQLKH()
        {
            InitializeComponent();
            _repository = new GenericRepository<KhachHang>();
            LoadTable();
            SetupValidationEvents();
        }

        private void LoadTable()
        {
            var data = _repository.GetAll().ToList();

            dgvQLKH.Columns.Clear();
            dgvQLKH.AutoGenerateColumns = false;

            var columns = new (string Name, string Header)[]
            {
                (nameof(KhachHang.MaKhachHang), "Mã KH"),
                (nameof(KhachHang.TenKhachHang), "Tên KH"),
                (nameof(KhachHang.SoDienThoai), "SĐT"),
                (nameof(KhachHang.Email), "Email"),
                (nameof(KhachHang.DiaChi), "Địa chỉ"),
                (nameof(KhachHang.GioiTinh), "Giới tính")
            };

            foreach (var col in columns)
            {
                dgvQLKH.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = col.Name,
                    HeaderText = col.Header,
                    Name = col.Name,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }

            dgvQLKH.DataSource = data;

            dgvQLKH.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    _selectedKhachHang = dgvQLKH.Rows[e.RowIndex].DataBoundItem as KhachHang;
                    FillForm(_selectedKhachHang);
                }
            };
        }
        // Hàm tự động tạo mã khách hàng mới
        private int GenerateNewEmployeeId()
        {
            var allCustomers = _repository.GetAll();
            if (allCustomers == null || !allCustomers.Any())
            {
                return 1; // Bắt đầu từ 1 nếu chưa có nhân viên nào
            }

            return allCustomers.Max(e => e.MaKhachHang) + 1;
        }

        private void FillForm(KhachHang kh)
        {
            if (kh == null) return;

            txtMaKH.Text = kh.MaKhachHang.ToString();
            txtTenKH.Text = kh.TenKhachHang;
            txtSDT.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;

            if (!string.IsNullOrEmpty(kh.GioiTinh))
            {

                for (int i = 0; i < cbGioiTinh.Items.Count; i++)
                {
                    if (string.Equals(cbGioiTinh.Items[i].ToString(), kh.GioiTinh, StringComparison.OrdinalIgnoreCase))
                    {
                        cbGioiTinh.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cbGioiTinh.SelectedIndex = -1;
            }
        }

        private void ClearInputs()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cbGioiTinh.SelectedIndex = -1;
            txtMaKH.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (!int.TryParse(txtMaKH.Text.Trim(), out int maKH))
            //{
            //    MessageBox.Show("Mã khách hàng phải là số nguyên!", "Lỗi");
            //    return;
            //}

            // Tự động tạo mã nhân viên
            int maKH = GenerateNewEmployeeId();

            var khMoi = new KhachHang()
            {
                MaKhachHang = maKH,
                TenKhachHang = txtTenKH.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                GioiTinh = cbGioiTinh.SelectedItem?.ToString()
            };

            if (_repository.GetAll().Any(k => k.MaKhachHang == maKH))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!", "Lỗi");
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

            _repository.Add(khMoi);
            LoadTable();
            ClearInputs();
            MessageBox.Show("Thêm khách hàng thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa");
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

            _selectedKhachHang.TenKhachHang = txtTenKH.Text.Trim();
            _selectedKhachHang.SoDienThoai = txtSDT.Text.Trim();
            _selectedKhachHang.Email = txtEmail.Text.Trim();
            _selectedKhachHang.DiaChi = txtDiaChi.Text.Trim();
            _selectedKhachHang.GioiTinh = cbGioiTinh.SelectedItem?.ToString();

            _repository.Update(_selectedKhachHang);
            LoadTable();
            MessageBox.Show("Cập nhật khách hàng thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {_selectedKhachHang.TenKhachHang}?",
                                          "Xác nhận", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _repository.Remove(_selectedKhachHang);
                LoadTable();
                ClearInputs();
                MessageBox.Show("Xóa khách hàng thành công!");
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void FormQLKH_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }
        private void SetupValidationEvents()
        {
            // Sự kiện validate số điện thoại (chỉ cho nhập số)
            txtSDT.KeyPress += txtSDT_KeyPress;
            txtSDT.Leave += txtSDT_Leave;

            // Sự kiện validate email
            txtEmail.Leave += txtEmail_Leave;
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

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email phải có định dạng @gmail.com!", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
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
    }
}
