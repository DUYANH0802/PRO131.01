using Microsoft.Data.SqlClient;
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
    public partial class FormRegister : Form
    {
        string connectionString = @"Server=NGUYENDUYANH\SQLEXPRESS;Database=PRO131_01;Trusted_Connection=True;TrustServerCertificate=True;";

        public FormRegister()
        {
            InitializeComponent();
            LoadRole();
        }

        private void LoadRole()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT MaQuyen, TenQuyen FROM PhanQuyen", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboRole.DisplayMember = "TenQuyen";
                cboRole.ValueMember = "MaQuyen";
                cboRole.DataSource = dt;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUser.Text.Trim();
            string password = txtNewPass.Text.Trim();

            if (username == "" || password == "" || cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

            
                string checkSql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap=@u";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@u", username);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              
                string insertSql = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaQuyen) VALUES (@u, @p, @r)";
                SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@u", username);
                insertCmd.Parameters.AddWithValue("@p", password);
                insertCmd.Parameters.AddWithValue("@r", cboRole.SelectedValue);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void chkShowPassReg_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = !chkShowPassReg.Checked;
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

        }
    }
}
