using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaiTapLon.Model;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaiTapLon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : Controller
    {
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<khachhang> Get()
        {
            khachhang khachhang = new khachhang();
            khachhang.type = "get";
            DataSet ds = dbconnect.KhachHangGet(khachhang, out msg);
            List<khachhang> list = new List<khachhang>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new khachhang
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenKH = dr["TenKH"].ToString(),
                    Anh = dr["Anh"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    TK = dr["TK"].ToString(),
                    Pass = dr["Pass"].ToString(),
                });
            }
            return list;
        }

        // GET api/<khachhangController>/5
        [HttpGet("{id}")]
        public List<khachhang> Get(int id)
        {
            khachhang khachhang = new khachhang();
            khachhang.id = id;
            khachhang.type = "getid";
            DataSet ds = dbconnect.KhachHangGet(khachhang, out msg);
            List<khachhang> list = new List<khachhang>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new khachhang
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenKH = dr["TenKH"].ToString(),
                    Anh = dr["Anh"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    TK = dr["TK"].ToString(),
                    Pass = dr["Pass"].ToString(),
                });
            }
            return list;
        }

        // POST api/<khachhangController>
        [HttpPost]
        public JsonResult Post([FromBody] khachhang khachhang)
        {
            string msg = string.Empty;
            try
            {
                khachhang.type = "insert";
                msg = dbconnect.KhachHangOpt(khachhang);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<khachhangController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] khachhang khachhang)
        {
            string msg = string.Empty;
            try
            {
                khachhang.id = id;
                khachhang.type = "update";
                msg = dbconnect.KhachHangOpt(khachhang);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // DELETE api/<khachhangController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                khachhang khachhang = new khachhang();
                khachhang.id = id;
                khachhang.type = "delete";
                msg = dbconnect.KhachHangOpt(khachhang);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
    }
}
