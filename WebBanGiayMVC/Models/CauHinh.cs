namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHinh")]
    public partial class CauHinh
    {
        public int Id { get; set; }
        
        public string TenCauHinh { get; set; }
        
        public string MaCauHinh { get; set; }
        
        public string GiaTriCauHinh { get; set; }
      
        public int? Loai { get; set; }
        
        public int? TrangThai { get; set; }

        public string MoTa { get; set; }
    }
}
