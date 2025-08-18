using PRO131_01.Extentions;
using PRO131_01.Models;
using PRO131_01.Services;

namespace PRO131_01
{
    public partial class Form1 : Form
    {
        SanPhamServices _sanPhamservice;

        private string currentImagePath = "";
        public Form1()
        {
            InitializeComponent();
            _sanPhamservice = new SanPhamServices();
            LoadTable();
        }
        private void LoadTable()
        {
            dataGridView1.DataSource = _sanPhamservice.GetProductsWithInclude(nameof(SanPham.MaLoaiSanPhamNavigation));

            
            if (dataGridView1.Columns["MaSanPham"] != null)
                dataGridView1.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";

            if (dataGridView1.Columns["TenSanPham"] != null)
                dataGridView1.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";

            if (dataGridView1.Columns["SoLuongTonKho"] != null)
                dataGridView1.Columns["SoLuongTonKho"].HeaderText = "Số Lượng Tồn Kho";

            if (dataGridView1.Columns["GiaBan"] != null)
                dataGridView1.Columns["GiaBan"].HeaderText = "Giá Bán";

            if (dataGridView1.Columns["MoTa"] != null)
                dataGridView1.Columns["MoTa"].HeaderText = "Mô Tả";

            if (dataGridView1.Columns["HinhAnh"] != null)
                dataGridView1.Columns["HinhAnh"].HeaderText = "Hình Ảnh";

            if (dataGridView1.Columns["TenSanPhamChiTiet"] != null)
                dataGridView1.Columns["TenSanPhamChiTiet"].HeaderText = "Tên sản phẩm chi tiết";


        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is SanPham sanPham)
            {
                textBoxMa.Text = sanPham.MaSanPham.ToString();
                textBoxTen.Text = sanPham.TenSanPham ?? string.Empty;
                numericUpDownSoLuong.Value = (decimal)(sanPham.SoLuongTonKho ?? 0);

               
                if (comboBoxLoaiSp.DataSource != null && sanPham.MaLoaiSanPham != null)
                {
                    comboBoxLoaiSp.SelectedValue = sanPham.MaLoaiSanPham;
                }
                else
                {
                    comboBoxLoaiSp.SelectedIndex = -1;
                }

               
                txtGiaBan.Text = sanPham.GiaBan?.ToString() ?? "0";

             
                string path = @"../../../Images/NoImage.png";
                if (!string.IsNullOrWhiteSpace(sanPham.HinhAnh) && File.Exists(sanPham.HinhAnh))
                {
                    path = sanPham.HinhAnh;
                }
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh";
                openFileDialog.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;

                  
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string imagesFolder = Path.Combine(projectDirectory, "Images");

                  
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                 
                    string fileName = Path.GetFileName(sourcePath);
                    string destinationPath = Path.Combine(imagesFolder, fileName);

                   
                    File.Copy(sourcePath, destinationPath, true);

                    currentImagePath = destinationPath;

                  
                    pictureBox1.Image = Image.FromFile(destinationPath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    MessageBox.Show(currentImagePath);
                }
            }
        }

        private void BindingToModel(SanPham sanPham)
        {
            sanPham.MaSanPham = int.TryParse(textBoxMa.Text, out int ma) ? ma : 0;
            sanPham.TenSanPham = textBoxTen.Text;
            sanPham.MoTa = RichTextBoxMoTa.Text;
            sanPham.SoLuongTonKho = numericUpDownSoLuong.Value != null
    ? (int)numericUpDownSoLuong.Value
    : (int?)null;

            sanPham.SoLuongTonKho = (int)numericUpDownSoLuong.Value;
            sanPham.HinhAnh = currentImagePath;
          
            if (decimal.TryParse(txtGiaBan.Text, out decimal gia))
                sanPham.GiaBan = gia;
            else
                sanPham.GiaBan = null;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();
            BindingToModel(sanPham);
            _sanPhamservice.Them(sanPham);
            LoadTable();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is SanPham sanPham)
            {
                int index = dataGridView1.CurrentRow.Index;
                BindingToModel(sanPham);
                _sanPhamservice.Sua(sanPham);
                LoadTable();
                dataGridView1.Rows[index].Selected = true;
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is SanPham sanPham)
            {
                _sanPhamservice.Xoa(sanPham);
                LoadTable();
            }
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            textBoxMa.Text = "";
            textBoxTen.Text = "";
            RichTextBoxMoTa.Text = "";
            comboBoxLoaiSp.SelectedIndex = -1;
            numericUpDownSoLuong.Value = 0;
            txtGiaBan.Text = "0";
            pictureBox1.Image = null;
            LoadTable();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                var list = _sanPhamservice.GetProducts();

                dataGridView1.DataSource = list.TimKiem(textBoxTimKiem.Text.Trim());
                //  string a = "";
                // a.Contains("3", StringComparison.CurrentCultureIgnoreCase);
            }

        }

        private void comboBoxLSP_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
           
            if (!decimal.TryParse(txtGiaBan.Text, out _))
            {
                txtGiaBan.Text = "0";
            }
        }
    }
}
