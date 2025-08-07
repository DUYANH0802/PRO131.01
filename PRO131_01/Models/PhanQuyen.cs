using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("PhanQuyen")]
public partial class PhanQuyen
{
    [Key]
    public int MaQuyen { get; set; }

    [StringLength(50)]
    public string? TenQuyen { get; set; }

    [InverseProperty("MaQuyenNavigation")]
    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
