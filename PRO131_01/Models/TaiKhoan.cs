using System;
using System.Collections.Generic;

namespace PRO131_01.Models;

public partial class TaiKhoan
{
    public string TenDangNhap { get; set; } = null!;

    public string? MatKhau { get; set; }

    public int? MaQuyen { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaKhachHang { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual PhanQuyen? MaQuyenNavigation { get; set; }
}
