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
    
    public partial class ChiTietPhieuDB
    {
        public string MaPhieu { get; set; }
        public string MaMonAn { get; set; }
        public string MaLoai { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<decimal> GiamGia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    
        public virtual LoaiMon LoaiMon { get; set; }
        public virtual MonAn MonAn { get; set; }
        public virtual PhieuDatBan PhieuDatBan { get; set; }
    }
}
