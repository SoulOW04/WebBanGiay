using PagedList;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;
using System.Xml.Linq;
using WebBanGiayMVC.Service.SanPham.ViewModel;

namespace WebBanGiayMVC.Controllers
{
    public class TrangChuController : Controller
    {
        private const string gioHang = "gioHang";//key

        //service
        SanPhamTrongDanhMucService sanPhamTrongDanhMucService;
        CauHinhService cauHinhService;
        //DanhMucService danhMucService;
        SanPhamService sanPhamService;
        SanPham sp;
        ThongSoSanPhamService thongSoSanPhamService;
        //data_context
        Model_Context db = new Model_Context();
        //Cau Hinh
        CauHinh cauHinh = new CauHinh();
        public TrangChuController()
        {
            cauHinhService = new CauHinhService();
            sanPhamTrongDanhMucService = new SanPhamTrongDanhMucService();
            thongSoSanPhamService = new ThongSoSanPhamService();
            sanPhamService = new SanPhamService();
            sp = new SanPham();
        }
        // GET: TrangChu
        public ActionResult Index(string keyword = "", int index = 1, int size = 4)
        {
            var total = 0;
            var sanPham = sanPhamService.FilterSanPham(out total, keyword, index, size);
            
            if (sanPham != null)
            {
                ViewBag.SanPham = sanPham;
            }

            
            
            //search Sanpham
            
            

            //lay cau hinh logo
            var cauHinhLogo = cauHinhService.GetCauHinhByMaCauHinh("Logo");
            if (cauHinhLogo != null)
            {
                ViewBag.Logo = cauHinhLogo.GiaTriCauHinh;
            }



            //cau hinh cua women
            var cauHinhWomenBanner = cauHinhService.GetCauHinhByMaCauHinh("IndexWomenBanner");
            if (cauHinhWomenBanner != null)
            {
                ViewBag.WomenBanner = cauHinhWomenBanner.GiaTriCauHinh;
            }
            //cau hinh cua men
            var cauHinhMenBanner = cauHinhService.GetCauHinhByMaCauHinh("IndexMenBanner");
            if (cauHinhMenBanner != null)
            {
                ViewBag.MenBanner = cauHinhMenBanner.GiaTriCauHinh;
            }
            //lay cau hinh banner
            var cauHinhBanner = cauHinhService.GetCauHinhByLoai(1);
            if (cauHinhBanner != null)
            {
                ViewBag.Banner = cauHinhBanner.ToList();
            }

           
           

            

            //if (!String.IsNullOrEmpty(searchSanPhamByName))

            
            return View(sanPham);

            //sanpham = sanpham.Where(s => s.TenSanPham.Contains(searchSanPhamByName));

            //sanpham = sanpham.OrderBy(s => s.TenSanPham);

            //int pageSize = 5;
            //int No_Of_Page = (page ?? 1);

            //return View(sanpham.ToPagedList(No_Of_Page, pageSize));
            
        }
        public ActionResult About()
        {
            var cauHinhProc = cauHinhService.GetCauHinhByMaCauHinh("About");
            if (cauHinhProc != null)
            {
                ViewBag.Anh = cauHinhProc.GiaTriCauHinh;
                ViewBag.TieuDe = cauHinhProc.TenCauHinh;
                ViewBag.MoTa = cauHinhProc.MoTa;
            }
            return View();
        }
        public ActionResult Add_To_Wishlist()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }

        public PartialViewResult HeaderCart()
        {
            var cart = Session[gioHang];
            var list = new List<GioHangItem>();
            if (cart != null)
            {
                list = (List<GioHangItem>)cart;//ep kieu cart sang list 
            }

            return PartialView(list);
        }


        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Men(string keyword = "", int index = 1, int size = 5)
        {
            var total = 0;
            var sanPham = sanPhamService.FilterSanPhamInDanhMuc(out total, keyword, index, size,21);
            ViewBag.Total = total;
            ViewBag.Index = index;
            ViewBag.Size = size;
            ViewBag.Keyword = keyword;
            if (sanPham != null)
            {
                ViewBag.SanPhamMen = sanPham;
            }
            var CauHinhBanner = cauHinhService.GetCauHinhByMaCauHinh("MenBanner");
            if (CauHinhBanner != null)
            {
                ViewBag.AnhCH = CauHinhBanner.GiaTriCauHinh;
                ViewBag.TenCH = CauHinhBanner.TenCauHinh;

            }
            var CauHinhBanner1 = cauHinhService.GetCauHinhByMaCauHinh("FirstBanner");
            if (CauHinhBanner1 != null)
            {
                ViewBag.AnhCH1 = CauHinhBanner1.GiaTriCauHinh;
                ViewBag.TenCH1 = CauHinhBanner1.TenCauHinh;

            }
            var CauHinhBanner2 = cauHinhService.GetCauHinhByMaCauHinh("SecondBanner");
            if (CauHinhBanner2 != null)
            {
                ViewBag.AnhCH2 = CauHinhBanner2.GiaTriCauHinh;
                ViewBag.TenCH2 = CauHinhBanner2.TenCauHinh;
            }
            var CauHinhBanner3 = cauHinhService.GetCauHinhByMaCauHinh("ThirdBanner");
            if (CauHinhBanner3 != null)
            {
                ViewBag.AnhCH3 = CauHinhBanner3.GiaTriCauHinh;
                ViewBag.TenCH3 = CauHinhBanner3.TenCauHinh;
            }
            var cauHinhSanPhamTheoDanhMuc = sanPhamTrongDanhMucService.GetSanPhamTrongDanhMucByDanhMucId(21);
            if (cauHinhSanPhamTheoDanhMuc != null)
            {
                ViewBag.SanPham = cauHinhSanPhamTheoDanhMuc.ToList();
            }
            return View(sanPham);
        }
        public ActionResult Women(string keyword = "", int index = 1, int size = 5)
        {
            var total = 0;
            var sanPham = sanPhamService.FilterSanPham(out total, keyword, index, size);
            ViewBag.Total = total;
            ViewBag.Index = index;
            ViewBag.Size = size;
            ViewBag.Keyword = keyword;
            if (sanPham != null)
            {
                ViewBag.SanPhamWomen = sanPham;
            }
            //loai 2 = muc Casual
            var CauHinhBanner = cauHinhService.GetCauHinhByMaCauHinh("WomenBanner");
            if (CauHinhBanner != null)
            {
                ViewBag.AnhCH = CauHinhBanner.GiaTriCauHinh;
                ViewBag.TenCH = CauHinhBanner.TenCauHinh;

            }
            var CauHinhBanner1 = cauHinhService.GetCauHinhByMaCauHinh("FirstBanner");
            if (CauHinhBanner1 != null)
            {
                ViewBag.AnhCH1 = CauHinhBanner1.GiaTriCauHinh;
                ViewBag.TenCH1 = CauHinhBanner1.TenCauHinh;
            }
            var CauHinhBanner2 = cauHinhService.GetCauHinhByMaCauHinh("SecondBanner");
            if (CauHinhBanner2 != null)
            {
                ViewBag.AnhCH2 = CauHinhBanner2.GiaTriCauHinh;
                ViewBag.TenCH2 = CauHinhBanner2.TenCauHinh;
            }
            var CauHinhBanner3 = cauHinhService.GetCauHinhByMaCauHinh("ThirdBanner");
            if (CauHinhBanner3 != null)
            {
                ViewBag.AnhCH3 = CauHinhBanner3.GiaTriCauHinh;
                ViewBag.TenCH3 = CauHinhBanner3.TenCauHinh;
            }
           
            var cauHinhSanPhamTheoDanhMuc = sanPhamTrongDanhMucService.GetSanPhamTrongDanhMucByDanhMucId(20);
            if (cauHinhSanPhamTheoDanhMuc != null)
            {
                ViewBag.SanPham = cauHinhSanPhamTheoDanhMuc.ToList();
            }

            return View(sanPham);
        }

        public ActionResult Product_Detail(int id)
        {
            var product = sanPhamService.GetChiTietSanPham(id);
            if(product != null)
            {
                var thongSoKyThuats = sanPhamService.GetThongSoSanPhams(id);
                ViewBag.TSKT = thongSoKyThuats;
                return View(product);
            }
            return null;
            
            
        }
    }
}