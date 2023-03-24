namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "TenDanhMuc is required")]
        public string TenDanhMuc { get; set; }
        
        public string MoTaDanhmuc { get; set; }
        [Required(ErrorMessage = "BannerDanhMuc is required")]
        public string BannerDanhMuc { get; set; }
        [Required(ErrorMessage = "AvatarDanhMuc is required")]
        public string AvatarDanhMuc { get; set; }
        [Required(ErrorMessage = "ParentId is required")]
        public int? ParentId { get; set; }
        [Required(ErrorMessage = "ErrorMessage is required")]
        public int? Loai { get; set; }
        [Required(ErrorMessage = "TrangThai is required")]
        public int? TrangThai { get; set; }
    }
}
