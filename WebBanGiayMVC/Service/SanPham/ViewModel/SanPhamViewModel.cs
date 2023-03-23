using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Service.SanPham.ViewModel
{
    public class SanPhamViewModel
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "TenSanPham is required")]
        public string TenSanPham { get; set; }
        [Required(ErrorMessage = "MoTaSanPham is required")]
        public string MoTaSanPham { get; set; }
        [Required(ErrorMessage = "GiaSanPham is required")]
        public int? GiaSanPham { get; set; }
        [Required(ErrorMessage = "AvatarSanPham is required")]
        public string AvatarSanPham { get; set; }
        [Required(ErrorMessage = "DanhSachAnhSanPham is required")]
        public string DanhSachAnhSanPham { get; set; }
        [Required(ErrorMessage = "NoiDungSanPham is required")]
        public string NoiDungSanPham { get; set; }
        [Required(ErrorMessage = "HangSanPham is required")]
        public string HangSanPham { get; set; }
        [Required(ErrorMessage = "Loai is required")]
        public int? Loai { get; set; }
        [Required(ErrorMessage = "TrangThai is required")]
        public int? TrangThai { get; set; }
    }

    public class InsertSanPhamWithDanhMucs : WebBanGiayMVC.Service.SanPham.ViewModel.SanPhamViewModel
    {
        [Required(ErrorMessage = "DanhSachDanhMucs is required")]
        public string DanhSachDanhMucs { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public List<ThongSoInsertUpdate> ThongSoInsertUpdates { get; set; }
    }
    public class InsertSanPhamFull : WebBanGiayMVC.Service.SanPham.ViewModel.SanPhamViewModel
    {
        [Required(ErrorMessage = "DanhSachDanhMucs is required")]
        public string DanhSachDanhMucs { get; set; }
        
        public List<ThongSoInsertUpdate> ThongSoInsertUpdates { get; set; }
    }

    public class ThongSoInsertUpdate
    {
        [Required(ErrorMessage = "ThongSoId is required")]
        public int? ThongSoId { get; set; }
        [Required(ErrorMessage = "GiaTri is required")]
        public string GiaTri { get; set; }
    }


    public class ThongSoSanPhamHT
    {
        [Required(ErrorMessage = "ThongSo_Id is required")]
        public int ThongSo_Id { get; set; }
        [Required(ErrorMessage = "ThongSo_Ten is required")]
        public string ThongSo_Ten { get; set; }
        [Required(ErrorMessage = "GiaTri is required")]
        public string GiaTri { get; set; }
    }

    public class GioHangItem
    {
        public WebBanGiayMVC.Models.SanPham SanPham { get; set; }
        public int ThongSo_Id { get; set; }
        public string ThongSo_GiaTri { get; set; }
        public int SoLuong { get; set; }
    }



}