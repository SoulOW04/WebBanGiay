using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class AdminController : Controller
    {
        AdminService adminService;
        public AdminController()
        {
            adminService = new AdminService();
        }
        public ActionResult Index()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login");
            }else
            { 
                return View();
            }

        }
        // GET: Admin
        public ActionResult Login(string name,string passWord)
        {
            var giaSanPham = adminService.GetAdminByLogin(name, passWord);
            if(giaSanPham != null)
            {
                Session["Name"] = name;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["alert"] = "Sai tên tài khoản hoặc mật khẩu";
                return View();
            }
            
        }
    }
}