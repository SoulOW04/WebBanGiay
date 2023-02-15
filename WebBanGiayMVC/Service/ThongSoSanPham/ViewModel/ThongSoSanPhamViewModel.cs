using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiayMVC.Service.ThongSoSanPham.ViewModel
{
    public class ThongSoSanPhamViewModel
    {
        public int Id { get; set; }

        public string AvatarSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int SoLuong { get; set; }

        public int GiaSanPham { get; set; }

        public string MoTaSanPham { get; set; }

        public string NoiDungSanPham { get; set; }

        public string HangSanPham { get; set; }

        public string StyleSanPham { get; set; }

        public string Mau { get; set; }

        public int KichThuocSanPham { get; set; }
    }
}