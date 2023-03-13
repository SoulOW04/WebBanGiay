using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Index(int? page, string searchSanPhamByName, string currentFilter)
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

            var sanpham = from s in db.SanPhams
                          select s;
            if (searchSanPhamByName != null)
                page = 1;
            else
                searchSanPhamByName = currentFilter;

            ViewBag.CurrentFilter = searchSanPhamByName;

            if (!String.IsNullOrEmpty(searchSanPhamByName))
                sanpham = sanpham.Where(s => s.TenSanPham.Contains(searchSanPhamByName));

            sanpham = sanpham.OrderBy(s => s.TenSanPham);

            int pageSize = 5;
            int No_Of_Page = (page ?? 1);

            return View(sanpham.ToPagedList(No_Of_Page, pageSize));
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
