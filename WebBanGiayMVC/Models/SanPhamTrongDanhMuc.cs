namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPhamTrongDanhMuc")]
    public partial class SanPhamTrongDanhMuc
    {
        public int Id { get; set; }

        public int? DanhMucId { get; set; }

        public int? SanPhamId { get; set; }
    }
}
