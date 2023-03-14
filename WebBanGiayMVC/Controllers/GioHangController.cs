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
            var cart = Session[gioHang];
            var list = new List<ThongSoSanPhamViewModel>();
            if (cart != null)
            {
                list = (List<ThongSoSanPhamViewModel>)cart;//ep kieu cart sang list 
                ////
                //string json = JsonConvert.SerializeObject(list);
                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //ExcelPackage excelPackage = new ExcelPackage();
                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Data");
                
            }

            if (cart == null)
            {
                
            }

            //lay giaSpFOrmat
            var giaSanPham = sanPhamService.GetAllGiaSanPhamFormat();

            if (giaSanPham != null)
            {
                ViewBag.SanPham = giaSanPham;
            }

            //lay all san pham
            var sp = sanPhamService.GetAllGiaSanPhamFormat();

            if (sp != null)
            {
                ViewBag.Sp = sp;
            }
            return View(list);
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<ThongSoSanPhamViewModel>)Session[gioHang];
            sessionCart.RemoveAll(x => x.SanPhamId == id);
            Session[gioHang] = sessionCart; 
            return Json(new { 
            
                status = true
            });

        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ThongSoSanPhamDA().GetThongTinSanPhamById(productId);
            var cart = Session[gioHang];
            if (cart != null)
            {
                var list = (List<ThongSoSanPhamViewModel>)cart;
                if (list.Exists(x => x.SanPhamId == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPhamId == productId)
                        {
                            item.SoLuong += quantity;
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng Chi Tiet Don Hang 
                    var item = new ThongSoSanPhamViewModel();
                    item.SanPhamId = product.SanPhamId; 
                    item.SoLuong = quantity;
                    item.KichThuocSanPham = product.KichThuocSanPham;
                    item.AvatarSanPham = product.AvatarSanPham;
                    item.GiaSanPham = product.GiaSanPham;
                    item.TenSanPham = product.TenSanPham;
                    
                    list.Add(item);
                }
                //Gán vào session
                Session[gioHang] = list;
            }
            else
            {

                //Tạo mới đối tượng Chi Tiet Don Hang 
                var item = new ThongSoSanPhamViewModel();
                item.SanPhamId = product.SanPhamId;
                item.SoLuong = quantity;
                item.KichThuocSanPham = product.KichThuocSanPham;
                item.AvatarSanPham = product.AvatarSanPham;
                item.GiaSanPham = product.GiaSanPham;
                item.TenSanPham = product.TenSanPham;

                var list = new List<ThongSoSanPhamViewModel>();
                list.Add(item);

                //Gán vào session
                Session[gioHang] = list;

            }
            return RedirectToAction("Cart");
            //return View(product);
        }

        public ActionResult Checkout(int id, string tenSanPham, string soLuong, int gia, int kichThuoc )
        {

            var cart = Session[gioHang];
            var list = new List<ThongSoSanPhamViewModel>();
            if (cart != null)
            {
                list = (List<ThongSoSanPhamViewModel>)cart;//ep kieu cart sang list 
            }
            return View();
        }

        public ActionResult Order_Complete()
        {
            return View();
        }
    }
}