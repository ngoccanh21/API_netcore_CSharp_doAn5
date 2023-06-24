using BaiTapLon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;
using BaiTapLon.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace BaiTapLon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonBanController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly AdDbContext _context;
        public HoaDonBanController(IConfiguration configuration, IWebHostEnvironment env, AdDbContext adDbContext)
        {
            _context = adDbContext;

            _configuration = configuration;
            _env = env;
        }
        dbconnect dbconnect = new dbconnect();
        string msg = string.Empty;
        // GET: api/<LoaiSanPhamController>
        [HttpGet]
        public IActionResult Get()
        {
            var userdatails = _context.Orders1.ToList();
            return Ok(userdatails);
        }
        // GET api/<SanPhamController>/5
        [HttpGet("{MaHDB}")]
        public List<hoadonban> Get(int MaHDB)
        {
            hoadonban hoadonban = new hoadonban();
            hoadonban.MaHDB = MaHDB;
            hoadonban.type = "getid";
            DataSet ds = dbconnect.HoaDonBanGet(hoadonban, out msg);
            List<hoadonban> list = new List<hoadonban>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new hoadonban
                {
                    //MaHDB,NgayBan,id_kh
                    MaHDB = Convert.ToInt32(dr["MaHDB"]),
                    //NgayBan = dr["NgayBan"].ToString(),
                    id_kh = Convert.ToInt32(dr["id_kh"]),
                    //SoLuong = Convert.ToInt32(dr["SoLuong"]),
                });
            }
            return list;
        }

        // POST api/<SanPhamController>
        [HttpPost]
        public JsonResult Post([FromBody] hoadonban hoadonban)
        {
            string msg = string.Empty;
            try
            {
                hoadonban.type = "insert";
                msg = dbconnect.HoaDonBan(hoadonban);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("{MaHDB}")]
        public JsonResult Put(int MaHDB, [FromBody] hoadonban hoadonban)
        {
            string msg = string.Empty;
            try
            {
                hoadonban.MaHDB = MaHDB;
                hoadonban.type = "update";
                msg = dbconnect.HoaDonBan(hoadonban);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{MaHDB}")]
        public JsonResult Delete(int MaHDB)
        {
            string msg = string.Empty;
            try
            {
                hoadonban hoadonban = new hoadonban();
                hoadonban.MaHDB = MaHDB;
                hoadonban.type = "delete";
                msg = dbconnect.HoaDonBan(hoadonban);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { message = msg });
        }
        [Route("checkout")]
        [HttpPost]
        public IActionResult Createbill([FromBody] checkout model)
        {
            _context.khachhang.Add(model.kh);
            _context.SaveChanges();
            int id_kh = model.kh.id;
            hoadonban1 dh = new hoadonban1();
            //dh.makh = makh;
            dh.NgayBan = DateTime.Now;
            dh.id_kh = id_kh;
            _context.Orders1.Add(dh);
            _context.SaveChanges();
            int MaHDB = dh.MaHDB;

            if (model.donhang.Count > 0)
            {
                foreach (var item in model.donhang)
                {
                    item.id_hdb = MaHDB;
                    _context.DetailOrders.Add(item);
                }
                _context.SaveChanges();
            }
            return Ok(new { data = "OK" });

        }
    }
    public class checkout
    {
        public khachhang1 kh { get; set; }
        public List<cthdb1> donhang { get; set; }
    }
}
