using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BaiTapLon.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BaiTapLon.Model
{
    public class user
    {
        public int id { get; set; } = 0;
        public string TenKH { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string SDT { get; set; } = "";
        public string TK { get; set; } = "";
        public string Pass { get; set; } = "";

        public string Anh { get; set; } = "";
        //public string type { get; set; } = "";
    }
}
