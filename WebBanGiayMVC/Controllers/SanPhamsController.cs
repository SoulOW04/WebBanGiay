using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model_Context db = new Model_Context();
        SanPhamTrongDanhMucService sanPhamTrongDanhMucService;
        CauHinhService cauHinhService;
        DanhMucService danhMucService;
        SanPhamService sanPhamService;
        SanPham sp;
        ThongSoSanPhamService thongSoSanPhamService;

        CauHinh cauHinh = new CauHinh();

        // GET: SanPhams
        public SanPhamsController() {
            cauHinhService = new CauHinhService();
            sanPhamTrongDanhMucService = new SanPhamTrongDanhMucService();
            thongSoSanPhamService = new ThongSoSanPhamService();
            sanPhamService = new SanPhamService();
            sp = new SanPham();
        }

        public ActionResult Index(string keyword = "", int index = 1, int size = 5)
        {
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
            var total = 0;
            var sanphamFilter = sanPhamService.FilterSanPham(out total, keyword, index, size);
            return View(sanphamFilter);
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
