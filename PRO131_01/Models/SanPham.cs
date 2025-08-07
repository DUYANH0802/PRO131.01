using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    public int MaSanPham { get; set; }

    [StringLength(100)]
    public string? TenSanPham { get; set; }

    public string? MoTa { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? GiaBan { get; set; }

    public int? SoLuongTonKho { get; set; }

    [StringLength(255)]
    public string? HinhAnh { get; set; }

    public int? MaLoaiSanPham { get; set; }

    public int? MaNhaCungCap { get; set; }

    [InverseProperty("MaSanPhamNavigation")]
    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    [ForeignKey("MaLoaiSanPham")]
    [InverseProperty("SanPhams")]
    public virtual SanPhamChiTiet? MaLoaiSanPhamNavigation { get; set; }

    [ForeignKey("MaNhaCungCap")]
    [InverseProperty("SanPhams")]
    public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
}
