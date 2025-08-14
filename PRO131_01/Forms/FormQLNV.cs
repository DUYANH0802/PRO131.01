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
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;


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
            LoadTable();
        }
        private void LoadTable()
        {
            // Khởi tạo giá trị cho ComboBox giới tính
            cbGioitinh.Items.AddRange(new string[] { "Nam", "Nữ"});
            cbGioitinh.SelectedIndex = -1; // Chưa chọn giá trị mặc định

            dgvQLNV.DataSource = _repository.GetAll();
            dgvQLNV.AutoGenerateColumns = false;
            dgvQLNV.Columns.Clear();

            var columns = new (string Name, string Header, string DataProperty)[]
            {
            ("colMaNV", "Mã NV", nameof(NhanVien.MaNhanVien)),
            ("colHoTen", "Họ tên", nameof(NhanVien.HoTen)),
            ("colSdt", "SĐT", nameof(NhanVien.Sdt)),
            ("colEmail", "Email", nameof(NhanVien.Email)),
            ("colDiaChi", "Địa chỉ", nameof(NhanVien.DiaChi)),
            ("colGioiTinh", "Giới tính", nameof(NhanVien.GioiTinh))
            };

            foreach (var col in columns)
            {
                var dataColumn = new DataGridViewTextBoxColumn
                {
                    Name = col.Name,
                    HeaderText = col.Header,
                    DataPropertyName = col.DataProperty // Liên kết với property của NhanVien
                };
                dgvQLNV.Columns.Add(dataColumn);
            }
        }
        private void dgvQLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvQLNV.RowCount) return;

            try
            {
                var row = dgvQLNV.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["colMaNV"].Value?.ToString() ?? "";
                txtHoten.Text = row.Cells["colHoTen"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["colSdt"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["colEmail"].Value?.ToString() ?? "";
                txtDiachi.Text = row.Cells["colDiaChi"].Value?.ToString() ?? "";

                // Xử lý giới tính
                string gioiTinh = dgvQLNV.Rows[e.RowIndex].Cells["colGioiTinh"].Value?.ToString();
                if (!string.IsNullOrEmpty(gioiTinh))
                {
                    int index = cbGioitinh.FindStringExact(gioiTinh);
                    cbGioitinh.SelectedIndex = index >= 0 ? index : -1;
                }
                else
                {
                    cbGioitinh.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn nhân viên: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
                {
                    MessageBox.Show("Mã nhân viên phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNV.Focus();
                    return;
                }

                var NhanVienMoi = new NhanVien()
                {
                    MaNhanVien = maNV,
                    HoTen = txtHoten.Text.Trim(),
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim(),
                    GioiTinh = cbGioitinh.SelectedItem?.ToString()
                };

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

                if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
                {
                    MessageBox.Show("Họ tên không được để trống", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
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


    }
}
