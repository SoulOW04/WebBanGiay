namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoKiThuat")]
    public partial class ThongSoKiThuat
    {
        public int Id { get; set; }

        public string StyleSanPham { get; set; }

        public string Mau { get; set; }

        public int? KichThuocSanPham { get; set; }
    }
}
