//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ChiTietHoaDonNhap
    {
        public string MaNguyenLieu { get; set; }
        public string MaHoaDonNhap { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public string KhuyenMai { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    
        public virtual HoaDonNhap HoaDonNhap { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}