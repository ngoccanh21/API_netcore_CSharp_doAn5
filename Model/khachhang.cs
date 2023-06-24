using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    public class khachhang
    {
       
        public int id { get; set; } = 0;
        public string TenKH { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string SDT { get; set; } = "";
        public string TK { get; set; } = "";
        public string Pass { get; set; } = "";

        public string Anh { get; set; } = "";
        public string type { get; set; } = "";
    }
}
