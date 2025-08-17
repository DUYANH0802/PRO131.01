using PRO131_01.Models;
using PRO131_01.Repositories;
using System;
using System.Linq;
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
            if (!int.TryParse(txtMaKH.Text.Trim(), out int maKH))
            {
                MessageBox.Show("Mã KH phải là số nguyên!", "Lỗi");
                return;
            }

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
                MessageBox.Show("Mã KH đã tồn tại!", "Lỗi");
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
                MessageBox.Show("Vui lòng chọn KH cần sửa");
                return;
            }

            _selectedKhachHang.TenKhachHang = txtTenKH.Text.Trim();
            _selectedKhachHang.SoDienThoai = txtSDT.Text.Trim();
            _selectedKhachHang.Email = txtEmail.Text.Trim();
            _selectedKhachHang.DiaChi = txtDiaChi.Text.Trim();
            _selectedKhachHang.GioiTinh = cbGioiTinh.SelectedItem?.ToString();

            _repository.Update(_selectedKhachHang);
            LoadTable();
            MessageBox.Show("Cập nhật KH thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng chọn KH cần xóa");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa KH {_selectedKhachHang.TenKhachHang}?",
                                          "Xác nhận", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _repository.Remove(_selectedKhachHang);
                LoadTable();
                ClearInputs();
                MessageBox.Show("Xóa KH thành công!");
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
    }
}
