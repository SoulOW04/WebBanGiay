using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiayMVC.Service.DonHang.ViewModel
{
    public class DonHangItem
    {
        public string Ten { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int KetQua { get; set; }
        public string ThongSoSP { get; set; }
        public int TongGia { get; set; }
    }
}