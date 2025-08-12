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

namespace PRO131_01.Forms
{
    public partial class FormQLNV : Form
    {
        GenericRepository<NhanVien> _repository;
        public FormQLNV()
        {
            InitializeComponent();
            _repository = new GenericRepository<NhanVien>();
            LoadTable();
        }
        private void LoadTable() 
        {
            table1.DataSource = _repository.GetAll();
            table1.Columns = new AntdUI.ColumnCollection
            {
                new AntdUI.Column(nameof(NhanVien.MaNhanVien),"Mã nhân viên").SetDefaultFilter(),
                new AntdUI.Column(nameof(NhanVien.HoTen),"Họ tên ").SetSortOrder(),
                new AntdUI.Column(nameof(NhanVien.Sdt),"Số điện thoại"),
                new AntdUI.Column(nameof(NhanVien.Email),"Email"),
                new AntdUI.Column(nameof(NhanVien.DiaChi),"Địa chỉ"),
                new AntdUI.Column(nameof(NhanVien.GioiTinh),"Giới tính"),

            };
        }

    }
}
