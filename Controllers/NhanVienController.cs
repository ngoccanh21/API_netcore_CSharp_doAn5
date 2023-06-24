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
    public class NhanVienController : Controller
    {
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<NhanVienController>
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<nhanvien> Get()
        {
            nhanvien nv = new nhanvien();
            nv.type = "get";
            DataSet ds = dbconnect.NhanVienGet(nv, out msg);
            List<nhanvien> list = new List<nhanvien>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new nhanvien
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenNV = dr["TenNV"].ToString(),
                    GT = dr["GT"].ToString(),
                    NgaySinh = dr["NgaySinh"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    QueQuan = dr["QueQuan"].ToString(),
                    Email = dr["Email"].ToString(),
                    capbac = dr["capbac"].ToString(),
                });
            }
            return list;
        }
        // GET api/<LoaiSanPhamController>/5
        [HttpGet("{id}")]
        public List<nhanvien> Get(int id)
        {
            nhanvien nv = new nhanvien();
            nv.id = id;
            nv.type = "getid";
            DataSet ds = dbconnect.NhanVienGet(nv, out msg);
            List<nhanvien> list = new List<nhanvien>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new nhanvien
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenNV = dr["TenNV"].ToString(),
                    GT = dr["GT"].ToString(),
                    NgaySinh = dr["NgaySinh"].ToString(),
                    SDT = dr["SDT"].ToString(),
                    QueQuan = dr["QueQuan"].ToString(),
                    Email = dr["Email"].ToString(),
                    capbac = dr["capbac"].ToString(),

                });
            }
            return list;
        }

        // POST api/<LoaiSanPhamController>
        [HttpPost]
        public JsonResult Post([FromBody] nhanvien nv)
        {
            string msg = string.Empty;
            try
            {
                nv.type = "insert";
                msg = dbconnect.NhanVienOpt(nv);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<LoaiSanPhamController>/5
        [HttpPut("(id)")]
        public JsonResult Put(int id, [FromBody] nhanvien nv)
        {
            string msg = string.Empty;
            try
            {
                nv.id = id;
                nv.type = "update";
                msg = dbconnect.NhanVienOpt(nv);
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
                nhanvien nv = new nhanvien();
                nv.id = id;
                nv.type = "delete";
                msg = dbconnect.NhanVienOpt(nv);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
    }
}
