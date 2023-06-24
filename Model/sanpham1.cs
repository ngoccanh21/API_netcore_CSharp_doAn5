using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Model
{
    public class sanpham1
    {
        [Key]
        //id MaLoai TenSP GiaBan Sale SoLuong TinhTrang Anh MoTa type
        public int id { get; set; } = 0;
        public int MaLoai { get; set; } = 0;
        public string TenSP { get; set; } = "";
        public int GiaBan { get; set; } = 0;
        public int Sale { get; set; } = 0;
        public int SoLuong { get; set; } = 0;
        public string TinhTrang { get; set; } = "";
        public string Anh { get; set; } = "";
        public string MoTa { get; set; } = "";
    }
}
