namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        public int Id { get; set; }

        public string TenSanPham { get; set; }

        public string MoTaSanPham { get; set; }

        public int? GiaSanPham { get; set; }

        public string AvatarSanPham { get; set; }

        public string DanhSachAnhSanPham { get; set; }

        public string NoiDungSanPham { get; set; }

        public string HangSanPham { get; set; }

        public int? Loai { get; set; }

        public int? TrangThai { get; set; }
    }
}
