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

namespace PRO131_01.Forms
{
    public partial class FormQLKH : Form
    {
        GenericRepository<KhachHang> _repository;
        public FormQLKH()
        {
            InitializeComponent();
            _repository = new GenericRepository<KhachHang>();
            LoadTable();
        }
        private void LoadTable() 
        {
            table1.DataSource = _repository.GetAll();
            table1.Columns = new AntdUI.ColumnCollection
{
    new AntdUI.Column(nameof(KhachHang.MaKhachHang), "Mã khách hàng").SetDefaultFilter(),
    new AntdUI.Column(nameof(KhachHang.TenKhachHang), "Họ tên").SetSortOrder(),
    new AntdUI.Column(nameof(KhachHang.SoDienThoai), "SĐT"),
    new AntdUI.Column(nameof(KhachHang.Email), "Email"),
    new AntdUI.Column(nameof(KhachHang.DiaChi), "Địa chỉ"),
    new AntdUI.Column(nameof(KhachHang.GioiTinh), "Giới tính"),

};
        }
    }
}
