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
    public class TinTucController : Controller
    {
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<tintuc> Get()
        {
            tintuc tintuc = new tintuc();
            tintuc.type = "get";
            DataSet ds = dbconnect.TinTucGet(tintuc, out msg);
            List<tintuc> list = new List<tintuc>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new tintuc
                {
                    //id tieuDe noiDung1 noiDung2 ngayTao anh anh2
                    id = Convert.ToInt32(dr["id"]),
                    tieuDe = dr["tieuDe"].ToString(),
                    noiDung1 = dr["noiDung1"].ToString(),
                    noiDung2 = dr["noiDung2"].ToString(),
                    ngayTao = dr["ngayTao"].ToString(),
                    anh = dr["anh"].ToString(),
                    anh2 = dr["anh2"].ToString(),
                });
            }
            return list;
        }

        // GET api/<LoaiSanPhamController>/5
        [HttpGet("{id}")]
        public List<tintuc> Get(int id)
        {
            tintuc tintuc = new tintuc();
            tintuc.id = id;
            tintuc.type = "getid";
            DataSet ds = dbconnect.TinTucGet(tintuc, out msg);
            List<tintuc> list = new List<tintuc>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new tintuc
                {
                    //id tieuDe noiDung1 noiDung2 ngayTao anh anh2
                    id = Convert.ToInt32(dr["id"]),
                    tieuDe = dr["tieuDe"].ToString(),
                    noiDung1 = dr["noiDung1"].ToString(),
                    noiDung2 = dr["noiDung2"].ToString(),
                    ngayTao = dr["ngayTao"].ToString(),
                    anh = dr["anh"].ToString(),
                    anh2 = dr["anh2"].ToString(),
                });
            }
            return list;
        }

        // POST api/<LoaiSanPhamController>
        [HttpPost]
        public JsonResult Post([FromBody] tintuc tintuc)
        {
            string msg = string.Empty;
            try
            {
                tintuc.type = "insert";
                msg = dbconnect.TinTuc(tintuc);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] tintuc tintuc)
        {
            string msg = string.Empty;
            try
            {
                tintuc.id = id;
                tintuc.type = "update";
                msg = dbconnect.TinTuc(tintuc);
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
                tintuc tintuc = new tintuc();
                tintuc.id = id;
                tintuc.type = "delete";
                msg = dbconnect.TinTuc(tintuc);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
    }
}
