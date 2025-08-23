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
                SELECT MaHoaDon, NgayLap, TongTien, TrangThai, MaKhachHang, MaNhanVien
                FROM HoaDon
                WHERE (@from IS NULL OR NgayLap >= @from)
                  AND (@to   IS NULL OR NgayLap <= @to)
                ORDER BY NgayLap DESC;";

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
