using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Model
{
    public class khachhang1
    {
        [Key]
        public int id { get; set; } = 0;
        public string TenKH { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string SDT { get; set; } = "";
        public string TK { get; set; } = "";
        public string Pass { get; set; } = "";

        public string Anh { get; set; } = "";
    }
}
