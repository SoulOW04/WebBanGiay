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
        [Required(ErrorMessage = "MaDonHang is required")]
        public string MaDonHang { get; set; }
        [Required(ErrorMessage = "HoTen is required")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "DiaChi is required")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "ThanhPho is required")]
        public string ThanhPho { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "SoDienThoai is required")]
        public string SoDienThoai { get; set; }
        [Required(ErrorMessage = "NgayDatHang is required")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public string NgayDatHang { get; set; }
        [Required(ErrorMessage = "TrangThai is required")]
        public int? TrangThai { get; set; }
        [Required(ErrorMessage = "Loai is required")]
        public int? Loai { get; set; }
    }
}
