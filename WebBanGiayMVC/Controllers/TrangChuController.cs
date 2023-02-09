﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class TrangChuController : Controller
    {
        Model_Context db = new Model_Context();
        CauHinhService cauHinhService;
        CauHinh cauHinh = new CauHinh();
        public TrangChuController()
        {
            cauHinhService = new CauHinhService();
        }
        // GET: TrangChu
        public ActionResult Index()
        {
            //lay cau hinh logo
            var cauHinhLogo = cauHinhService.GetCauHinhByMaCauHinh("Logo");
            if (cauHinhLogo != null)
            {
                ViewBag.Logo = cauHinhLogo.GiaTriCauHinh;
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
        public ActionResult Product_Detail()
        {
            return View();
        }
    }
}