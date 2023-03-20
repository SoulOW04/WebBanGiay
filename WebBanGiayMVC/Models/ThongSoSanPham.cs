namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoSanPham")]
    public partial class ThongSoSanPham
    {
        public int Id { get; set; }

        public int? SanPhamId { get; set; }

        public int? ThongSoKiThuatId { get; set; }

        public string GiaTriSp { get; set; }
    }
}
