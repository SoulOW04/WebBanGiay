using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class GioHangController : Controller
    {
        //const la ham so khong the thay doi
        private const string gioHang = "gioHang";//key

        // GET: GioHang
        public ActionResult Index()
        {
            var cart = Session[gioHang];
            var list = new List<ChiTietDonHang>();
            if (cart != null)
            {
                list = (List<ChiTietDonHang>)cart;//ep kieu cart sang list 
            }
            return View(list);
        }

        public ActionResult AddItem(int productId,int quantity)
        {
            var cart = Session[gioHang];
            if (cart != null)
            {
                var list = (List<ChiTietDonHang>)cart;
                if (list.Exists(x=>x.SanPhamId == productId))
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
                    var item = new ChiTietDonHang();
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
                var item = new ChiTietDonHang();
                item.SanPhamId = productId;
                item.SoLuong = quantity;
                var list = new List<ChiTietDonHang>();
                list.Add(item);

                //Gán vào session
                Session[gioHang] = list;

            }
            return RedirectToAction("Index");
        }
    }
}