using PRO131_01.Models;
using PRO131_01.Services;

namespace PRO131_01
{
    public partial class Form1 : Form
    {
        SanPhamServices _sanPhamservice;
        public Form1()
        {
            InitializeComponent();
            _sanPhamservice = new SanPhamServices();
            LoadTable();
        }
        private void LoadTable()
        {
            dataGridView1.DataSource = _sanPhamservice.GetProductsWithInclude(nameof(SanPham.MaLoaiSanPhamNavigation));
            //dataGridView1.Columns[nameof(SanPham.MaSanPham)].HeaderText = "Ma san pham";
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
    }
}
