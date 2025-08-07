using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[PrimaryKey("MaHoaDon", "MaSanPham")]
[Table("HoaDonChiTiet")]
public partial class HoaDonChiTiet
{
    [Key]
    public int MaHoaDon { get; set; }

    [Key]
    public int MaSanPham { get; set; }

    public int? SoLuong { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DonGia { get; set; }

    [ForeignKey("MaHoaDon")]
    [InverseProperty("HoaDonChiTiets")]
    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;

    [ForeignKey("MaSanPham")]
    [InverseProperty("HoaDonChiTiets")]
    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
