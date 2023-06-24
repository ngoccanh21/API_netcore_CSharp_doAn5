using Microsoft.EntityFrameworkCore;
using System;
using System.Xml;
using BaiTapLon.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BaiTapLon.Data
{
    public class AdDbContext : DbContext
    {
        public AdDbContext(DbContextOptions<AdDbContext> options) : base(options)
        {

        }
        public DbSet<user> user { get; set; }
        public DbSet<hoadonban1> Orders1 { get; set; }
        public DbSet<khachhang1> khachhang { get; set; }
        public DbSet<cthdb1> DetailOrders { get; set; }
        public DbSet<sanpham1> SanPham { get; set; }
        //public DbSet<KhachHang1> khachhang { get; set; }
        //public DbSet<Cart> carts { get; set; }
        //public DbSet<Vot> vots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hoadonban1>().ToTable("HoaDonBan");
            modelBuilder.Entity<cthdb1>().ToTable("CTHDB");
            modelBuilder.Entity<khachhang1>().ToTable("KhachHang");
            modelBuilder.Entity<sanpham1>().ToTable("SanPham");

            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<Cart>().ToTable("cart");

            //modelBuilder.Entity<hoadonban1>(builder => { builder.HasNoKey(); builder.ToTable("HoaDonBan"); });
            //modelBuilder.Entity<cthdb1>(builder => { builder.HasNoKey(); builder.ToTable("CTHDB"); });
            //modelBuilder.Entity<khachhang1>(builder => { builder.HasNoKey(); builder.ToTable("KhachHang"); });

            //modelBuilder.Entity<user>().ToTable("khachhang");
            //modelBuilder.Entity<KhachHang1>().ToTable("KhachHang");

        }
    }
}