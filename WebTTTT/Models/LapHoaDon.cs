//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTTTT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LapHoaDon
    {
        public int tongTien { get; set; }
        public string tenNVlapHD { get; set; }
        public string maNV { get; set; }
        public string maHD { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
