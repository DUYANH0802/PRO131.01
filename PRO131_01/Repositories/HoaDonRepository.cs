using Microsoft.Data.SqlClient;
using System.Data;

namespace PRO131_01.Repositories
{
    public class HoaDonRepository
    {
        private readonly string _connStr;

        public HoaDonRepository(string connStr)
        {
            _connStr = connStr;
        }

        // Lọc theo khoảng ngày
        public DataTable FindByDateRange(DateOnly? from, DateOnly? to)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
        SELECT 
            hd.MaHoaDon,
            hd.NgayLap,
            hd.TongTien,
            hd.TrangThai,
            kh.TenKhachHang       AS [Khách hàng],
            nv.HoTen        AS [Nhân viên]
        FROM HoaDon hd
        INNER JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
        INNER JOIN NhanVien  nv ON hd.MaNhanVien  = nv.MaNhanVien
        WHERE (@from IS NULL OR hd.NgayLap >= @from)
          AND (@to   IS NULL OR hd.NgayLap < DATEADD(day, 1, @to))
        ORDER BY hd.NgayLap DESC;";



            var pFrom = new SqlParameter("@from", SqlDbType.Date)
            { Value = (object?)from?.ToDateTime(TimeOnly.MinValue) ?? DBNull.Value };

            var pTo = new SqlParameter("@to", SqlDbType.Date)
            { Value = (object?)to?.ToDateTime(TimeOnly.MinValue) ?? DBNull.Value };

            cmd.Parameters.Add(pFrom);
            cmd.Parameters.Add(pTo);

            var dt = new DataTable();
            conn.Open();
            using var rd = cmd.ExecuteReader();
            dt.Load(rd);
            return dt;
        }
    }
}
