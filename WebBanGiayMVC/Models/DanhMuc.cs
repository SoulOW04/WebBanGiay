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

        public string TenDanhMuc { get; set; }

        public string MoTaDanhmuc { get; set; }

        public string BannerDanhMuc { get; set; }

        public string AvatarDanhMuc { get; set; }

        public int? ParentId { get; set; }

        public int? Loai { get; set; }

        public int? TrangThai { get; set; }
    }
}
