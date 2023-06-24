using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLon.Model
{
    public class nhacungcap
    {
        //id TenNCC DiaChi SDT Email type
        public int id { get; set; } = 0;
        public string TenNCC { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string SDT { get; set; } = "";
        public string Email { get; set; } = "";
        public string type { get; set; } = "";
    }
}
