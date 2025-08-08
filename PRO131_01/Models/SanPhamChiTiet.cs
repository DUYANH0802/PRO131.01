using System;
using System.Collections.Generic;

namespace PRO131_01.Models;

public partial class SanPhamChiTiet
{
    public int MaSanPhamChiTiet { get; set; }

    public string? TenSanPhamChiTiet { get; set; }

    public string? KichThuoc { get; set; }

    public string? MauSac { get; set; }

    public int? SoLuongTon { get; set; }

    public decimal? GiaBan { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
