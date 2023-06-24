using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaiTapLon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BaiTapLon.Model;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using BaiTapLon.Data;
using BaiTapLon.Model;

namespace web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AdDbContext _context;
        private readonly IConfiguration _config;
        public LoginController(AdDbContext userDbContext, IConfiguration config)
        {
            _context = userDbContext;
            _config = config;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.user.AsQueryable();
            return Ok(userdetails);
        }
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] user userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.user.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    message = " them thanh cong"
                });

            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] user userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {


                var user = _context.user.Where(x => x.TK == userObj.TK && x.Pass == userObj.Pass).FirstOrDefault();
                if (user != null)
                {
                    var token = generateToken(user.TK);
                    return Ok(new
                    {
                        StatusCode = 200,
                        message = "dang nhap thanh cong !!!",
                        UserData = user.TK,
                        JwtToken = token
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        message = "ten dang nhap hoac mat khau khong dung",

                    });
                }


            }

        }
        private string generateToken(string Username)
        {
            var tokehandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Email,Username),
new Claim("ComapnyName","Canh")




            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential



            );


            return tokehandler.WriteToken(token);

        }
    }
}