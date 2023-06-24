using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaiTapLon.Model;
using System.Data;
using System.IO;
using System.Net.Http.Headers;

namespace BaiTapLon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTHDBController : Controller
    {
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<cthdb> Get()
        {
            cthdb cthdb = new cthdb();
            cthdb.type = "get";
            DataSet ds = dbconnect.CTHDBGet(cthdb, out msg);
            List<cthdb> list = new List<cthdb>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new cthdb
                {
                    //id_cthdb id_hdb id_sp tenSP giaBan soLuong thanhTien anh size
                    id_cthdb = Convert.ToInt32(dr["id_cthdb"]),
                    id_hdb = Convert.ToInt32(dr["id_hdb"]),
                    id_sp = Convert.ToInt32(dr["id_sp"]),
                    tenSP = dr["tenSP"].ToString(),
                    giaBan = Convert.ToInt32(dr["giaBan"]),
                    soLuong = Convert.ToInt32(dr["soLuong"]),
                    thanhTien = Convert.ToInt32(dr["thanhTien"]),
                    anh = dr["anh"].ToString(),
                    size = dr["size"].ToString(),
                });
            }
            return list;
        }

        // GET api/<khachhangController>/5
        [HttpGet("{id_cthdb}")]
        public List<cthdb> Get(int id_cthdb)
        {
            cthdb cthdb = new cthdb();
            cthdb.id_cthdb = id_cthdb;
            cthdb.type = "getid";
            DataSet ds = dbconnect.CTHDBGet(cthdb, out msg);
            List<cthdb> list = new List<cthdb>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new cthdb
                {
                    id_cthdb = Convert.ToInt32(dr["id_cthdb"]),
                    id_hdb = Convert.ToInt32(dr["id_hdb"]),
                    id_sp = Convert.ToInt32(dr["id_sp"]),
                    tenSP = dr["tenSP"].ToString(),
                    giaBan = Convert.ToInt32(dr["giaBan"]),
                    soLuong = Convert.ToInt32(dr["soLuong"]),
                    thanhTien = Convert.ToInt32(dr["thanhTien"]),
                    anh = dr["anh"].ToString(),
                    size = dr["size"].ToString(),
                });
            }
            return list;
        }

        // POST api/<khachhangController>
        [HttpPost]
        public JsonResult Post([FromBody] cthdb cthdb)
        {
            string msg = string.Empty;
            try
            {
                cthdb.type = "insert";
                msg = dbconnect.CTHDB(cthdb);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<khachhangController>/5
        [HttpPut("{id_cthdb}")]
        public JsonResult Put(int id_cthdb, [FromBody] cthdb cthdb)
        {
            string msg = string.Empty;
            try
            {
                cthdb.id_cthdb = id_cthdb;
                cthdb.type = "update";
                msg = dbconnect.CTHDB(cthdb);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // DELETE api/<khachhangController>/5
        [HttpDelete("{id_cthdb}")]
        public JsonResult Delete(int id_cthdb)
        {
            string msg = string.Empty;
            try
            {
                cthdb cthdb = new cthdb();
                cthdb.id_cthdb = id_cthdb;
                cthdb.type = "delete";
                msg = dbconnect.CTHDB(cthdb);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
    }
}
