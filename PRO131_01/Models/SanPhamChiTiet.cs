using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("SanPhamChiTiet")]
public partial class SanPhamChiTiet
{
    [Key]
    [Column("MaSanPhamChiTIet")]
    public int MaSanPhamChiTiet { get; set; }

    [StringLength(100)]
    public string? TenSanPhamChiTiet { get; set; }

    [StringLength(10)]
    public string? KichThuoc { get; set; }

    [StringLength(50)]
    public string? MauSac { get; set; }

    public int? SoLuongTon { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? GiaBan { get; set; }

    [StringLength(255)]
    public string? HinhAnh { get; set; }

    [InverseProperty("MaLoaiSanPhamNavigation")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
