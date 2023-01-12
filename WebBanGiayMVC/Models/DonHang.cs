namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        public int Id { get; set; }

        public string MaDonHang { get; set; }

        public string HoTen { get; set; }

        public string DiaChi { get; set; }

        public string ThanhPho { get; set; }

        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public string NgayDatHang { get; set; }

        public int? TrangThai { get; set; }

        public int? Loai { get; set; }
    }
}
