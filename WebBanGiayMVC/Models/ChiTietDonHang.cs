namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    [Serializable]
    public partial class ChiTietDonHang
    {
        public int Id { get; set; }

        public int? DonHangId { get; set; }

        public int? SanPhamId { get; set; }

        public int? SoLuong { get; set; }

        public int? GiaBan { get; set; }
    }
}
