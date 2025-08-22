using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO131_01.Models
{
    public class GioHangItem
    {
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien => (SanPham.GiaBan ?? 0) * SoLuong;

        public GioHangItem(SanPham sanPham, int soLuong)
        {
            SanPham = sanPham;
            SoLuong = soLuong;
        }
    }
}
