using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class TrangChuController : Controller
    {
        //service
        SanPhamTrongDanhMucService sanPhamTrongDanhMucService;
        CauHinhService cauHinhService;
        DanhMucService danhMucService;
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
        public ActionResult Index()
        {

            //lay giaSpFOrmat
            var giaSanPham = sanPhamService.GetAllGiaSanPhamFormat();

            if (giaSanPham != null)
            {
                ViewBag.SanPham = giaSanPham;
            }

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
            return View(db.SanPhams.ToList());
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
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Men()
        {
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
            var cauHinhSanPhamTheoDanhMuc = sanPhamTrongDanhMucService.GetSanPhamTrongDanhMucByDanhMucId(1);
            if (cauHinhSanPhamTheoDanhMuc != null)
            {
                ViewBag.SanPham = cauHinhSanPhamTheoDanhMuc.ToList();
            }

            return View(db.SanPhams.ToList());
        }
        public ActionResult Women()
        {
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
            var cauHinhSanPhamTheoDanhMuc = sanPhamTrongDanhMucService.GetSanPhamTrongDanhMucByDanhMucId(4);
            if (cauHinhSanPhamTheoDanhMuc != null)
            {
                ViewBag.SanPham = cauHinhSanPhamTheoDanhMuc.ToList();
            }

            return View(db.SanPhams.ToList());
        }
        public ActionResult Order_Complete()
        {
            return View();
        }
        public ActionResult Product_Detail(int id)
        {
            var product = new ThongSoSanPhamDA().GetThongTinSanPhamById(id);

            return View(product);
        }
    }
}