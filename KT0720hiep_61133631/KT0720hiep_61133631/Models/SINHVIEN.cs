//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KT0720hiep_61133631.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SINHVIEN
    {
        public string MASV { get; set; }
        public string HOSV { get; set; }
        public string TENSV { get; set; }
        public System.DateTime NGAYSINH { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public string ANHSV { get; set; }
        public string DIACHI { get; set; }
        public string MALOP { get; set; }
    
        public virtual LOP LOP { get; set; }
    }
}
