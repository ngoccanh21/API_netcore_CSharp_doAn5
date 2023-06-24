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
    public class LoaiSanPhamController : Controller
    {
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<loaisanpham> Get()
        {
            loaisanpham loai = new loaisanpham();
            loai.type = "get";
            DataSet ds = dbconnect.LoaisanphamGet(loai, out msg);
            List<loaisanpham> list = new List<loaisanpham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new loaisanpham
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenLoai = dr["TenLoai"].ToString(),
                    Anh = dr["Anh"].ToString(),
                });
            }
            return list;
        }

        // GET api/<LoaiSanPhamController>/5
        [HttpGet("{id}")]
        public List<loaisanpham> Get(int id)
        {
            loaisanpham loai = new loaisanpham();
            loai.id = id;
            loai.type = "getid";
            DataSet ds = dbconnect.LoaisanphamGet(loai, out msg);
            List<loaisanpham> list = new List<loaisanpham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new loaisanpham
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenLoai = dr["TenLoai"].ToString(),
                    Anh = dr["Anh"].ToString(),
                });
            }
            return list;
        }

        // POST api/<LoaiSanPhamController>
        [HttpPost]
        public JsonResult Post([FromBody] loaisanpham loai)
        {
            string msg = string.Empty;
            try
            {
                loai.type = "insert";
                msg = dbconnect.LoaisanphamOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] loaisanpham loai)
        {
            string msg = string.Empty;
            try
            {
                loai.id = id;
                loai.type = "update";
                msg = dbconnect.LoaisanphamOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // DELETE api/<LoaiSanPhamController>/5
        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                loaisanpham loai = new loaisanpham();
                loai.id = id;
                loai.type = "delete";
                msg = dbconnect.LoaisanphamOpt(loai);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
    }
}
