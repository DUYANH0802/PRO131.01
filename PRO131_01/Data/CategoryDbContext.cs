using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PRO131_01.Models;

namespace PRO131_01.Data;

public partial class CategoryDbContext : DbContext
{
    public CategoryDbContext()
    {
    }

    public CategoryDbContext(DbContextOptions<CategoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NGUYENDUYANH\\SQLEXPRESS;Database=PRO131_01;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13B2A61096C");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon).ValueGeneratedNever();
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDon__MaKhachH__44FF419A");

            entity.HasOne(d => d.MaKhuyenMaiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhuyenMai)
                .HasConstraintName("FK__HoaDon__MaKhuyen__46E78A0C");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDon__MaNhanVi__45F365D3");
        });

        modelBuilder.Entity<HoaDonChiTiet>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaSanPham }).HasName("PK__HoaDonCh__4CF2A579B4D42F60");

            entity.ToTable("HoaDonChiTiet");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonChi__MaHoa__49C3F6B7");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonChi__MaSan__4AB81AF0");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5CF2A987A");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenMai).HasName("PK__KhuyenMa__6F56B3BD1CD47060");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKhuyenMai).ValueGeneratedNever();
            entity.Property(e => e.DieuKienApDung).HasMaxLength(255);
            entity.Property(e => e.TenKhuyenMai).HasMaxLength(100);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNhaCungCap).HasName("PK__NhaCungC__53DA920556BA12FF");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNhaCungCap).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(100);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47C078B8CD");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__PhanQuye__1D4B7ED446226D13");

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.MaQuyen).ValueGeneratedNever();
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D29AB84ED");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSanPham).ValueGeneratedNever();
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.TenSanPham).HasMaxLength(100);

            entity.HasOne(d => d.MaLoaiSanPhamNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoaiSanPham)
                .HasConstraintName("FK__SanPham__MaLoaiS__3F466844");

            entity.HasOne(d => d.MaNhaCungCapNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNhaCungCap)
                .HasConstraintName("FK__SanPham__MaNhaCu__403A8C7D");
        });

        modelBuilder.Entity<SanPhamChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaSanPhamChiTiet).HasName("PK__SanPhamC__7DCA3ABC7C908938");

            entity.ToTable("SanPhamChiTiet");

            entity.Property(e => e.MaSanPhamChiTiet)
                .ValueGeneratedNever()
                .HasColumnName("MaSanPhamChiTIet");
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.KichThuoc).HasMaxLength(10);
            entity.Property(e => e.MauSac).HasMaxLength(50);
            entity.Property(e => e.TenSanPhamChiTiet).HasMaxLength(100);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("PK__TaiKhoan__55F68FC10930F548");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(255);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__TaiKhoan__MaKhac__5812160E");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__TaiKhoan__MaNhan__571DF1D5");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaQuyen)
                .HasConstraintName("FK__TaiKhoan__MaQuye__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
