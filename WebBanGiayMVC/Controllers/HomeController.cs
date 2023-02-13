﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;

namespace WebBanGiayMVC.Controllers
{
    public class HomeController : Controller
    {
        DanhMucService danhMucService = new DanhMucService();
        public ActionResult Index()
        {
            //var model = danhMucService.GetAllDanhMucs();
            return View();
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