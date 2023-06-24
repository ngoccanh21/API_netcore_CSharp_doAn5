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
    public class NhaCungCapController : Controller
    {
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<nhacungcap> Get()
        {
            nhacungcap nhacungcap = new nhacungcap();
            nhacungcap.type = "get";
            DataSet ds = dbconnect.NhaCungCapGet(nhacungcap, out msg);
            List<nhacungcap> list = new List<nhacungcap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new nhacungcap
                {
                    //id TenNCC DiaChi SDT Email type
                    id = Convert.ToInt32(dr["id"]),
                    TenNCC = dr["TenNCC"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    Email = dr["Email"].ToString(),
                });
            }
            return list;
        }
        // GET api/<SanPhamController>/5
        [HttpGet("{id}")]
        public List<nhacungcap> Get(int id)
        {
            nhacungcap nhacungcap = new nhacungcap();
            nhacungcap.id = id;
            nhacungcap.type = "getid";
            DataSet ds = dbconnect.NhaCungCapGet(nhacungcap, out msg);
            List<nhacungcap> list = new List<nhacungcap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new nhacungcap
                {
                    //id TenNCC DiaChi SDT Email type
                    id = Convert.ToInt32(dr["id"]),
                    TenNCC = dr["TenNCC"].ToString(),
                    DiaChi = dr["DiaChi"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    Email = dr["Email"].ToString(),
                });
            }
            return list;
        }

        // POST api/<SanPhamController>
        [HttpPost]
        public JsonResult Post([FromBody] nhacungcap nhacungcap)
        {
            string msg = string.Empty;
            try
            {
                nhacungcap.type = "insert";
                msg = dbconnect.NhaCungCap(nhacungcap);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] nhacungcap nhacungcap)
        {
            string msg = string.Empty;
            try
            {
                nhacungcap.id = id;
                nhacungcap.type = "update";
                msg = dbconnect.NhaCungCap(nhacungcap);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                nhacungcap nhacungcap = new nhacungcap();
                nhacungcap.id = id;
                nhacungcap.type = "delete";
                msg = dbconnect.NhaCungCap(nhacungcap);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
    }
}
