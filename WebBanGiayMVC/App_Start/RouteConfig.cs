using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanGiayMVC
{
    //https://localhost:44356/GioHang/Order_Confirm
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
             
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "GioHang", action = "AddItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "GioHang",
                defaults: new { controller = "GioHang", action = "AddItem", id = UrlParameter.Optional }
            );
        }
    }
}
