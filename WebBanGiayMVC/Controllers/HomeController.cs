using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;

namespace WebBanGiayMVC.Controllers
{
    public class HomeController : Controller
    {
        private DanhMucService _danhMucService = new DanhMucService();
        public ActionResult Index()
        {
            var t = 0;
            ViewBag.TotalRaows = t;
            var model = _danhMucService.GetAllDanhMuc(out t);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}