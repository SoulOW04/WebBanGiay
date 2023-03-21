using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Models;

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

    public class InsertSanPhamWithDanhMucs : WebBanGiayMVC.Service.SanPham.ViewModel.SanPhamViewModel
    {
        public string DanhSachDanhMucs { get; set; }
        public List<ThongSoInsertUpdate> ThongSoInsertUpdates { get; set; }
    }
    public class InsertSanPhamFull : WebBanGiayMVC.Service.SanPham.ViewModel.SanPhamViewModel
    {
        public string DanhSachDanhMucs { get; set; }
        public List<ThongSoInsertUpdate> ThongSoInsertUpdates { get; set; }
    }

    public class ThongSoInsertUpdate
    {
        public int? ThongSoId { get; set; }
        public string GiaTri { get; set; }
    }


    public class ThongSoSanPhamHT
    {
        public int ThongSo_Id { get; set; }
        public string ThongSo_Ten { get; set; }
        public string GiaTri { get; set; }
    }

}