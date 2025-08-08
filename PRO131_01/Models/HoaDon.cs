using System;
using System.Collections.Generic;

namespace PRO131_01.Models;

public partial class HoaDon
{
    public int MaHoaDon { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaKhuyenMai { get; set; }

    public DateOnly? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual KhuyenMai? MaKhuyenMaiNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
