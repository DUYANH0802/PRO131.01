using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("TaiKhoan")]
public partial class TaiKhoan
{
    [Key]
    [StringLength(50)]
    public string TenDangNhap { get; set; } = null!;

    [StringLength(255)]
    public string? MatKhau { get; set; }

    public int? MaQuyen { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaKhachHang { get; set; }

    [ForeignKey("MaKhachHang")]
    [InverseProperty("TaiKhoans")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("TaiKhoans")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    [ForeignKey("MaQuyen")]
    [InverseProperty("TaiKhoans")]
    public virtual PhanQuyen? MaQuyenNavigation { get; set; }
}
