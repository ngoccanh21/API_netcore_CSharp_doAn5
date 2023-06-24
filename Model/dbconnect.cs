using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BaiTapLon.Model;


namespace BaiTapLon.Model
{
    public class dbconnect
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=demo_btl;Integrated Security=True");
        //Sản Phẩm
        public string LoaisanphamOpt(loaisanpham loai)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_LoaiSP", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", loai.id);
                com.Parameters.AddWithValue("TenLoai", loai.TenLoai);
                com.Parameters.AddWithValue("Anh", loai.Anh);
                com.Parameters.AddWithValue("type", loai.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet LoaisanphamGet(loaisanpham loai, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_LoaiSP", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", loai.id);
                com.Parameters.AddWithValue("TenLoai", loai.TenLoai);
                com.Parameters.AddWithValue("Anh", loai.Anh);
                com.Parameters.AddWithValue("type", loai.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        //Sản phẩm
        public string SanPhamOpt(sanpham sanpham)
        {
            string msg = string.Empty;
            try
            {
                //id MaLoai TenSP GiaBan Sale SoLuong TinhTrang Anh type
                SqlCommand com = new SqlCommand("SP_SanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", sanpham.id);
                com.Parameters.AddWithValue("MaLoai", sanpham.MaLoai);
                com.Parameters.AddWithValue("TenSP", sanpham.TenSP);
                com.Parameters.AddWithValue("GiaBan", sanpham.GiaBan);
                com.Parameters.AddWithValue("Sale", sanpham.Sale);
                com.Parameters.AddWithValue("SoLuong", sanpham.SoLuong);
                com.Parameters.AddWithValue("TinhTrang", sanpham.TinhTrang);
                com.Parameters.AddWithValue("Anh", sanpham.Anh);
                com.Parameters.AddWithValue("MoTa", sanpham.MoTa);
                com.Parameters.AddWithValue("type", sanpham.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet SanPhamGet(sanpham sanpham, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                //id MaLoai TenSP GiaBan Sale SoLuong TinhTrang Anh type
                SqlCommand com = new SqlCommand("SP_SanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", sanpham.id);
                com.Parameters.AddWithValue("MaLoai", sanpham.MaLoai);
                com.Parameters.AddWithValue("TenSP", sanpham.TenSP);
                com.Parameters.AddWithValue("GiaBan", sanpham.GiaBan);
                com.Parameters.AddWithValue("Sale", sanpham.Sale);
                com.Parameters.AddWithValue("SoLuong", sanpham.SoLuong);
                com.Parameters.AddWithValue("TinhTrang", sanpham.TinhTrang);
                com.Parameters.AddWithValue("Anh", sanpham.Anh);
                com.Parameters.AddWithValue("MoTa", sanpham.MoTa);
                com.Parameters.AddWithValue("type", sanpham.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //nhân viên
        public string NhanVienOpt(nhanvien nv)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_NhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", nv.id);
                com.Parameters.AddWithValue("TenNV", nv.TenNV);
                com.Parameters.AddWithValue("GT", nv.GT);
                com.Parameters.AddWithValue("QueQuan", nv.QueQuan);
                com.Parameters.AddWithValue("SDT", nv.SDT);
                com.Parameters.AddWithValue("type", nv.type);
                com.Parameters.AddWithValue("Email", nv.Email);
                com.Parameters.AddWithValue("capbac", nv.capbac);
                com.Parameters.AddWithValue("NgaySinh", nv.NgaySinh);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet NhanVienGet(nhanvien nv, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_NhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", nv.id);
                com.Parameters.AddWithValue("TenNV", nv.TenNV);
                com.Parameters.AddWithValue("GT", nv.GT);
                com.Parameters.AddWithValue("QueQuan", nv.QueQuan);
                com.Parameters.AddWithValue("SDT", nv.SDT);
                com.Parameters.AddWithValue("type", nv.type);
                com.Parameters.AddWithValue("Email", nv.Email);
                com.Parameters.AddWithValue("capbac", nv.capbac);
                com.Parameters.AddWithValue("NgaySinh", nv.NgaySinh);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //khách Hàng
        public string KhachHangOpt(khachhang khachhang)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("SP_KhachHang", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", khachhang.id);
                com.Parameters.AddWithValue("TenKH", khachhang.TenKH);
                com.Parameters.AddWithValue("Anh", khachhang.Anh);
                com.Parameters.AddWithValue("DiaChi", khachhang.DiaChi);
                com.Parameters.AddWithValue("SDT", khachhang.SDT);
                com.Parameters.AddWithValue("type", khachhang.type);
                com.Parameters.AddWithValue("TK", khachhang.TK);
                com.Parameters.AddWithValue("Pass", khachhang.Pass);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet KhachHangGet(khachhang khachhang, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("SP_KhachHang", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", khachhang.id);
                com.Parameters.AddWithValue("TenKH", khachhang.TenKH);
                com.Parameters.AddWithValue("Anh", khachhang.Anh);
                com.Parameters.AddWithValue("DiaChi", khachhang.DiaChi);
                com.Parameters.AddWithValue("SDT", khachhang.SDT);
                com.Parameters.AddWithValue("type", khachhang.type);
                com.Parameters.AddWithValue("TK", khachhang.TK);
                com.Parameters.AddWithValue("Pass", khachhang.Pass);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        

        //tin tuc
        public string TinTuc(tintuc tintuc)
        {
            string msg = string.Empty;
            try
            {
                //id tieuDe noiDung1 noiDung2 ngayTao anh anh2
                SqlCommand com = new SqlCommand("SP_TinTuc", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", tintuc.id);
                com.Parameters.AddWithValue("tieuDe", tintuc.tieuDe);
                com.Parameters.AddWithValue("noiDung1", tintuc.noiDung1);
                com.Parameters.AddWithValue("noiDung2", tintuc.noiDung2);
                com.Parameters.AddWithValue("ngayTao", tintuc.ngayTao);
                com.Parameters.AddWithValue("anh", tintuc.anh);
                com.Parameters.AddWithValue("anh2", tintuc.anh2);
                com.Parameters.AddWithValue("type", tintuc.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet TinTucGet(tintuc tintuc, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                //id tieuDe noiDung1 noiDung2 ngayTao anh anh2
                SqlCommand com = new SqlCommand("SP_TinTuc", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", tintuc.id);
                com.Parameters.AddWithValue("tieuDe", tintuc.tieuDe);
                com.Parameters.AddWithValue("noiDung1", tintuc.noiDung1);
                com.Parameters.AddWithValue("noiDung2", tintuc.noiDung2);
                com.Parameters.AddWithValue("ngayTao", tintuc.ngayTao);
                com.Parameters.AddWithValue("anh", tintuc.anh);
                com.Parameters.AddWithValue("anh2", tintuc.anh2);
                com.Parameters.AddWithValue("type", tintuc.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        //nhà cung cấp
        public string NhaCungCap(nhacungcap nhacungcap)
        {
            string msg = string.Empty;
            try
            {
                //id TenNCC DiaChi SDT Email type
                SqlCommand com = new SqlCommand("SP_NhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", nhacungcap.id);
                com.Parameters.AddWithValue("TenNCC", nhacungcap.TenNCC);
                com.Parameters.AddWithValue("DiaChi", nhacungcap.DiaChi);
                com.Parameters.AddWithValue("SDT", nhacungcap.SDT);
                com.Parameters.AddWithValue("Email", nhacungcap.Email);
                com.Parameters.AddWithValue("type", nhacungcap.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet NhaCungCapGet(nhacungcap nhacungcap, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                //id TenNCC DiaChi SDT Email type
                SqlCommand com = new SqlCommand("SP_NhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id", nhacungcap.id);
                com.Parameters.AddWithValue("TenNCC", nhacungcap.TenNCC);
                com.Parameters.AddWithValue("DiaChi", nhacungcap.DiaChi);
                com.Parameters.AddWithValue("SDT", nhacungcap.SDT);
                com.Parameters.AddWithValue("Email", nhacungcap.Email);
                com.Parameters.AddWithValue("type", nhacungcap.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        //hoá đơn bán
        public string HoaDonBan(hoadonban hoadonban)
        {
            string msg = string.Empty;
            try
            {
                //MaHDB,NgayBan,id_kh
                SqlCommand com = new SqlCommand("SP_HoaDonBan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaHDB", hoadonban.MaHDB);
                com.Parameters.AddWithValue("NgayBan", hoadonban.NgayBan);
                com.Parameters.AddWithValue("id_kh", hoadonban.id_kh);
                com.Parameters.AddWithValue("type", hoadonban.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet HoaDonBanGet(hoadonban hoadonban, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                //MaHDB,NgayBan,id_kh
                SqlCommand com = new SqlCommand("SP_HoaDonBan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("MaHDB", hoadonban.MaHDB);
                com.Parameters.AddWithValue("NgayBan", hoadonban.NgayBan);
                com.Parameters.AddWithValue("id_kh", hoadonban.id_kh);
                com.Parameters.AddWithValue("type", hoadonban.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
        //chi tiết hdb
        public string CTHDB(cthdb cthdb)
        {
            string msg = string.Empty;
            try
            {
                //id_cthdb id_hdb id_sp tenSP giaBan soLuong thanhTien anh size
                SqlCommand com = new SqlCommand("SP_CTHDB", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id_cthdb", cthdb.id_cthdb);
                com.Parameters.AddWithValue("id_hdb", cthdb.id_hdb);
                com.Parameters.AddWithValue("id_sp", cthdb.id_sp);
                com.Parameters.AddWithValue("tenSP", cthdb.tenSP);
                com.Parameters.AddWithValue("giaBan", cthdb.giaBan);
                com.Parameters.AddWithValue("soLuong", cthdb.soLuong);
                com.Parameters.AddWithValue("thanhTien", cthdb.thanhTien);
                com.Parameters.AddWithValue("anh", cthdb.anh);
                com.Parameters.AddWithValue("size", cthdb.size);
                com.Parameters.AddWithValue("type", cthdb.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet CTHDBGet(cthdb cthdb, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                //MaHDB,NgayBan,id_kh
                SqlCommand com = new SqlCommand("SP_CTHDB", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("id_cthdb", cthdb.id_cthdb);
                com.Parameters.AddWithValue("id_hdb", cthdb.id_hdb);
                com.Parameters.AddWithValue("id_sp", cthdb.id_sp);
                com.Parameters.AddWithValue("tenSP", cthdb.tenSP);
                com.Parameters.AddWithValue("giaBan", cthdb.giaBan);
                com.Parameters.AddWithValue("soLuong", cthdb.soLuong);
                com.Parameters.AddWithValue("thanhTien", cthdb.thanhTien);
                com.Parameters.AddWithValue("anh", cthdb.anh);
                com.Parameters.AddWithValue("size", cthdb.size);
                com.Parameters.AddWithValue("type", cthdb.type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}
