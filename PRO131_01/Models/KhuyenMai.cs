using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PRO131_01.Models;

[Table("KhuyenMai")]
public partial class KhuyenMai
{
    [Key]
    public int MaKhuyenMai { get; set; }

    [StringLength(100)]
    public string? TenKhuyenMai { get; set; }

    public int? GiaTriGiam { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    [StringLength(255)]
    public string? DieuKienApDung { get; set; }

    [InverseProperty("MaKhuyenMaiNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
