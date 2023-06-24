using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Model
{
    public class hoadonban1
    {
        [Key]
        public int MaHDB { get; set; } = 0;
        public DateTime NgayBan { get; set; }
        public int id_kh { get; set; } = 0;
    }
}
