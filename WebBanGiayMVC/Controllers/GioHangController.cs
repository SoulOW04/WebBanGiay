using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ChiTietDonHang.ViewModel;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;
using OfficeOpenXml;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;
using WebBanGiayMVC.Service.SanPham.ViewModel;
using WebBanGiayMVC.Service.DonHang.ViewModel;
using System.Security.Cryptography;
using System.Threading;

namespace WebBanGiayMVC.Controllers
{
    public class GioHangController : Controller
    {
        SanPhamService sanPhamService;
        SanPham sp;
        public GioHangController()
        {
            sanPhamService = new SanPhamService();
            sp = new SanPham();
        }


        //const la ham so khong the thay doi
        private const string gioHang = "gioHang";//key

        // GET: GioHang
        public ActionResult Cart()
        {
            var cart = Session["gioHang"];
            var list = new List<GioHangItem>();
            if (cart != null)
            {
                list = (List<GioHangItem>)cart;
                
                
                //ep kieu cart sang list 
                                               ////
                                               //string json = JsonConvert.SerializeObject(list);
                                               //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //ExcelPackage excelPackage = new ExcelPackage();
                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Data");

            }

           




            return View(list);
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<GioHangItem>)Session["gioHang"];
            sessionCart.RemoveAll(x => x.SanPham.Id == id);
            Session["gioHang"] = sessionCart;
            return Json(new
            {

                status = true
            });

        }
        [HttpGet]
        public ActionResult AddItem(int productId, int quantity, int thongSo_id, string thongSo_GiaTri)
        {
            if (productId > 0)
            {
                var prod = sanPhamService.GetChiTietSanPham(productId);
                if (prod != null)
                {
                    var gioHangIteam = new GioHangItem
                    {
                        SanPham = prod,
                        SoLuong = quantity,
                        ThongSo_Id = thongSo_id,
                        ThongSo_GiaTri = thongSo_GiaTri
                    };
                    var cart = Session["gioHang"];
                    if (cart == null) //<--Gio hang rong
                    {
                        var n_GioHang = new List<GioHangItem>();
                        n_GioHang.Add(gioHangIteam);

                        Session["gioHang"] = n_GioHang;
                    }
                    else
                    {
                        var n_GioHang = (List<GioHangItem>)Session["gioHang"];
                        foreach (var item in n_GioHang)
                        {
                            var idSp = item.SanPham.Id;
                            if (idSp == gioHangIteam.SanPham.Id)
                            {
                                var sPAff = n_GioHang.Where(R => R.SanPham.Id == idSp).FirstOrDefault();
                                if (sPAff != null)
                                {
                                    sPAff.SoLuong = sPAff.SoLuong + gioHangIteam.SoLuong;
                                    break;
                                }
                            }
                            else
                            {
                                n_GioHang.Add(gioHangIteam);
                                break;
                            }
                        }
                        
                        Session["gioHang"] = n_GioHang;
                    }
                    var cart_s = Session["gioHang"];
                    var list = new List<GioHangItem>();


                }
                RedirectToAction("Cart");
            }
            return null;

            //return View(product);
        }


        public ActionResult Payment()
        {

            var cart = Session["gioHang"];
            var list = new List<GioHangItem>();
            if (cart != null)
            {
                list = (List<GioHangItem>)cart;//ep kieu cart sang list 
            }
            return View();
        }


        public ActionResult Checkout()
        {

            var cart = Session["itemsThongTinSP"];
            //var list = new List<GioHangItem>();
            return View();
        }

        [HttpPost] 
        public ActionResult Checkout(GioHangItem item)
        {
            return RedirectToAction("GioHang", "Order_Complete");
        }
        


        public ActionResult Order_Complete()
        {
            return View();
        }
        //[HttpPost, ValidateInput(false)]
        [HttpPost]
        public ActionResult Order_Confirm(List<DonHangItem> items) //Viewmodel
        {
            Session["itemsThongTinSP"] = items ;
            List<int> list = new List<int>();
            foreach(var t in items)
            {
                var gia = 0;
                gia = t.TongGia;
                if(t == items.Last())
                {
                    list.Add(gia);
                }
                
            }
            Session["TongGiaSP"] = list;
            if (items.Count > 0)
            {
                return RedirectToAction("Checkout", "GioHang");
            }
            return null;
        }
    }
}