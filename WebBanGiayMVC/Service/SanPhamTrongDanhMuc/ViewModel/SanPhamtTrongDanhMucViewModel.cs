using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiayMVC.Service.SanPhamTrongDanhMuc.ViewModel
{
    public class SanPhamtTrongDanhMucViewModel
    {
        public int Id { get; set; }

        public int DanhMucId { get; set; }

        public int SanPhamId { get; set; }

        public string TenSanPham { get; set; }

        public string MoTaSanPham { get; set; }

        public int GiaSanPham { get; set; }

        public string AvatarSanPham { get; set; }

        public string DanhSachAnhSanPham { get; set; }

        public string NoiDungSanPham { get; set; }

        public string HangSanPham { get; set; }


    }
}