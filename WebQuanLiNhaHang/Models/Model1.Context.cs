﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQuanLiNhaHang.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLNhaHangEntities : DbContext
    {
        public QLNhaHangEntities()
            : base("name=QLNhaHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual DbSet<ChiTietPhieuDB> ChiTietPhieuDBs { get; set; }
        public virtual DbSet<CongDung> CongDungs { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<Khach> Khaches { get; set; }
        public virtual DbSet<LoaiMon> LoaiMons { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
        public virtual DbSet<NguyenLieu_MonAn> NguyenLieu_MonAn { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuDatBan> PhieuDatBans { get; set; }
        public virtual DbSet<Que> Ques { get; set; }
    }
}
