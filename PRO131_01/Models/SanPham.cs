using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PRO131_01.Models;

public partial class SanPham
{
    
    public int MaSanPham { get; set; }
   
    public string? TenSanPham { get; set; }
  
    public string? MoTa { get; set; }
    
    public decimal? GiaBan { get; set; }
   
    public int? SoLuongTonKho { get; set; }
 
    public string? HinhAnh { get; set; }
  
    public int? MaLoaiSanPham { get; set; }
  
    public int? MaNhaCungCap { get; set; }
    [Browsable(false)]
    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();
    [Browsable(false)]
    public virtual SanPhamChiTiet? MaLoaiSanPhamNavigation { get; set; }
    [Browsable(false)]
    public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
    public string TenSanPhamChiTiet 
    {
        get
        {
            return MaLoaiSanPhamNavigation?.TenSanPhamChiTiet ?? "chua ro";
        }
    }
}
