//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HanoiBusSystemManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BanVeNgay
    {
        public int MaGiaoDich { get; set; }
        public DateTime Ngay { get; set; }
        public Nullable<int> MaPhuXe { get; set; }
        public Nullable<int> MaVeNgay { get; set; }
        public int SoVePhatRa { get; set; }
        public int SoVeThuVe { get; set; }
    
        public virtual PhuXe PhuXe { get; set; }
        public virtual VeNgay VeNgay { get; set; }
    }
}