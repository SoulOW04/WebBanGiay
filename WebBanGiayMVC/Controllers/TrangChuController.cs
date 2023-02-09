using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class TrangChuController : Controller
    {
        CauHinhService cauHinhService;
        ThongSoSanPhamService thongSoSanPhamService;
        Model_Context db = new Model_Context();

        public TrangChuController()
        {
            cauHinhService = new CauHinhService();
            thongSoSanPhamService = new ThongSoSanPhamService();
        }
        // GET: TrangChu
        public ActionResult Index()
        {
            
            var cauHinhLogo = cauHinhService.GetCauHinhByMaCauHinh("Logo");
            if(cauHinhLogo != null)
            {
                ViewBag.Logo = cauHinhLogo.GiaTriCauHinh;
            }
            return View();
        }
        public ActionResult About()
        {
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
            return View();
        }
        public ActionResult Women()
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
            

            //SanPham sanPham = db.SanPhams.Find(id);
            //var sanPhamId = sanPham.Id;
            //if (sanPhamId != null)
            //{
            //    var chitTietDonHang = thongSoSanPhamService.GetThongTinSanPhamById(sanPhamId);
            //}
          
            
            return View();
        }
    }
}