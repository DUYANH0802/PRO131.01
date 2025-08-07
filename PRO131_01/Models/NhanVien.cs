using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("NhanVien")]
public partial class NhanVien
{
    [Key]
    public int MaNhanVien { get; set; }

    [StringLength(100)]
    public string? HoTen { get; set; }

    [Column("SDT")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Sdt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(255)]
    public string? DiaChi { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
