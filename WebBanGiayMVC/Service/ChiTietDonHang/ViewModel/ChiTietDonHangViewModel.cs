using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiayMVC.Service.ChiTietDonHang.ViewModel
{
    public class ChiTietDonHangViewModel
    {
        //Product Name [s].AvatarSanPham, [s].TenSanPham,[s].GiaSanPham,,SoLuong,GiaSP
        public int Id { get; set; }

        public string AvatarSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int SoLuong { get; set; }

        public int GiaBan { get; set; }
    }
}