using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    public int MaHoaDon { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaKhuyenMai { get; set; }

    public DateOnly? NgayLap { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TongTien { get; set; }

    [StringLength(50)]
    public string? TrangThai { get; set; }

    [InverseProperty("MaHoaDonNavigation")]
    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    [ForeignKey("MaKhachHang")]
    [InverseProperty("HoaDons")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    [ForeignKey("MaKhuyenMai")]
    [InverseProperty("HoaDons")]
    public virtual KhuyenMai? MaKhuyenMaiNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("HoaDons")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
