using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("NhaCungCap")]
public partial class NhaCungCap
{
    [Key]
    public int MaNhaCungCap { get; set; }

    [StringLength(100)]
    public string? TenNhaCungCap { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai { get; set; }

    [StringLength(255)]
    public string? DiaChi { get; set; }

    [InverseProperty("MaNhaCungCapNavigation")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
