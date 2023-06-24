using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    public class hoadonban
    {
        
        //MaHDB,NgayBan,id_kh
        //id_cthdb id_hdb id_sp tenSP giaBan soLuong thanhTien anh size
        public int MaHDB { get; set; } = 0;
        public DateTime NgayBan { get; set; }
        public int id_kh { get; set; } = 0;
        //public int SoLuong { get; set; } = 0;
        public string type { get; set; } = "";
    }
}
