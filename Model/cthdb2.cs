using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace BaiTapLon.Model
{
    public class cthdb2
    {
        [Key]
        public int id_cthdb { get; set; } = 0;
        public int id_hdb { get; set; } = 0;
        public int id_sp { get; set; } = 0;
        public string tenSP { get; set; } = "";
        public int giaBan { get; set; } = 0;
        public int soLuong { get; set; } = 0;
        public int thanhTien { get; set; } = 0;
        public string anh { get; set; } = "";
        public int size { get; set; } = 0;
    }
}
