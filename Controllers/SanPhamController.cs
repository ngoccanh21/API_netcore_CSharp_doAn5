using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaiTapLon.Model;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BaiTapLon.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaiTapLon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class SanPhamController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly AdDbContext _context;
        public SanPhamController(IConfiguration configuration, IWebHostEnvironment env, AdDbContext adDbContext)
        {
            _context = adDbContext;
            _configuration = configuration;
            _env = env;
        }
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public List<sanpham> Get()
        {
            sanpham sanpham = new sanpham();
            sanpham.type = "get";
            DataSet ds = dbconnect.SanPhamGet(sanpham, out msg);
            List<sanpham> list = new List<sanpham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new sanpham
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenSP = dr["TenSP"].ToString(),
                    Anh = dr["Anh"].ToString(),
                    MaLoai = Convert.ToInt32(dr["MaLoai"]),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    Sale = Convert.ToInt32(dr["Sale"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    TinhTrang = dr["TinhTrang"].ToString(),
                    MoTa = dr["MoTa"].ToString(),

                });
            }
            return list;
        }
        // GET api/<SanPhamController>/5
        [HttpGet("{id}")]
        public List<sanpham> Get(int id)
        {
            sanpham sanpham = new sanpham();
            sanpham.id = id;
            sanpham.type = "getid";
            DataSet ds = dbconnect.SanPhamGet(sanpham, out msg);
            List<sanpham> list = new List<sanpham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new sanpham
                {
                    id = Convert.ToInt32(dr["id"]),
                    TenSP = dr["TenSP"].ToString(),
                    Anh = dr["Anh"].ToString(),
                    MaLoai = Convert.ToInt32(dr["MaLoai"]),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    Sale = Convert.ToInt32(dr["Sale"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    TinhTrang = dr["TinhTrang"].ToString(),
                    MoTa = dr["MoTa"].ToString(),
                });
            }
            return list;
        }

        // POST api/<SanPhamController>
        [HttpPost]
        public JsonResult Post([FromBody] sanpham sanpham)
        {
            string msg = string.Empty;
            try
            {
                sanpham.type = "insert";
                msg = dbconnect.SanPhamOpt(sanpham);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] sanpham sanpham)
        {
            string msg = string.Empty;
            try
            {
                sanpham.id = id;
                sanpham.type = "update";
                msg = dbconnect.SanPhamOpt(sanpham);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message=msg });
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                sanpham sanpham = new sanpham();
                sanpham.id = id;
                sanpham.type = "delete";
                msg = dbconnect.SanPhamOpt(sanpham);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message=msg });
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.WebRootPath + "/images/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("erro");
            }
        }
        [HttpGet]
        [Route("api/sanphams/getsanphambyid/{MaLoai}")]
        public ActionResult GetSanPhamTheoLoai(int MaLoai)
        {
            var list = _context.SanPham.Where(sp => sp.MaLoai == MaLoai).ToList();
            return Ok(list);
        }


    }
}