using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ChiTietDonHang.ViewModel;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;

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
            var list = new List<ChiTietDonHangViewModel>();
            if (cart != null)
            {
                list = (List<ChiTietDonHangViewModel>)cart;//ep kieu cart sang list 
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

        public ActionResult AddItem(int productId, int quantity)
        {

            var cart = Session[gioHang];
            if (cart != null)
            {
                var list = (List<ChiTietDonHangViewModel>)cart;
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
                    var item = new ChiTietDonHangViewModel();
                    item.SanPhamId = productId;
                    item.SoLuong = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[gioHang] = list;
            }
            else
            {

                //Tạo mới đối tượng Chi Tiet Don Hang 
                var item = new ChiTietDonHangViewModel();
                item.SanPhamId = productId;
                item.SoLuong = quantity;
                var list = new List<ChiTietDonHangViewModel>();
                list.Add(item);

                //Gán vào session
                Session[gioHang] = list;

            }
            return RedirectToAction("Cart");
        }
    }
}