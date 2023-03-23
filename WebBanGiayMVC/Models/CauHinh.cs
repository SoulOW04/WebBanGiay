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
        [Required(ErrorMessage = "TenCauHinh is required")]
        public string TenCauHinh { get; set; }
        [Required(ErrorMessage = "MaCauHinh is required")]
        public string MaCauHinh { get; set; }
        [Required(ErrorMessage = "GiaTriCauHinh is required")]
        public string GiaTriCauHinh { get; set; }
        [Required(ErrorMessage = "Loai is required")]
        public int? Loai { get; set; }
        [Required(ErrorMessage = "TrangThai is required")]
        public int? TrangThai { get; set; }
        [Required(ErrorMessage = "MoTa is required")]
        public string MoTa { get; set; }
    }
}
