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
            comboBoxLoaiSp.DataSource = _sanPhamservice.GetProductsTypes();
            comboBoxLoaiSp.DisplayMember = nameof(SanPhamChiTiet.TenSanPhamChiTiet);
            comboBoxLoaiSp.ValueMember = nameof(SanPhamChiTiet.MaSanPhamChiTiet);

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
                // Mã sản phẩm
                textBoxMa.Text = sanPham.MaSanPham.ToString();

                // Tên sản phẩm
                textBoxTen.Text = sanPham.TenSanPham ?? string.Empty;

                // Số lượng (int? -> decimal)
                numericUpDownSoLuong.Value = (decimal)(sanPham.SoLuongTonKho ?? 0);

                // Gán loại sản phẩm vào ComboBox nếu có
                if (comboBoxLoaiSp.DataSource != null && sanPham.MaLoaiSanPham != null)
                {
                    comboBoxLoaiSp.SelectedValue = sanPham.MaLoaiSanPham;
                }
                else
                {
                    comboBoxLoaiSp.SelectedIndex = -1; // không chọn gì
                }

                // Hiển thị ảnh
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

                    // Lấy đường dẫn thư mục "images" trong thư mục dự án
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string imagesFolder = Path.Combine(projectDirectory, "Images");

                    // Tạo thư mục nếu chưa có
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    // Tạo tên file đích (giữ nguyên tên gốc)
                    string fileName = Path.GetFileName(sourcePath);
                    string destinationPath = Path.Combine(imagesFolder, fileName);

                    // Copy ảnh vào thư mục images (ghi đè nếu đã tồn tại)
                    File.Copy(sourcePath, destinationPath, true);

                    currentImagePath = destinationPath;

                    // Hiển thị ảnh từ thư mục images
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
            pictureBox1.Image = null;

        }
    }
}
