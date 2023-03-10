using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiayMVC.Service.SanPham.ViewModel
{
    public class SanPhamViewModel
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