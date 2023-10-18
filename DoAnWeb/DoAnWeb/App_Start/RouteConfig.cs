using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Tạo ra các URL dễ đọc và quản lý logic xử lý của ứng dụng, cùng với việc hỗ trợ tạo các chức năng tùy chỉnh
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                 name: "Contact",
                 url: "lien-he",
                 defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
                 namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
               name: "DetailNew",
               url: "{alias}-n{id}",
               defaults: new { controller = "News", action = "Detail", alias = UrlParameter.Optional },
               namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
               name: "NewsList",
               url: "tin-tuc",
               defaults: new { controller = "News", action = "Index", alias = UrlParameter.Optional },
               namespaces: new[] { "DoAnWeb.Controllers" }
                   );

            routes.MapRoute(
                name: "BaiViet",
                url: "post/{alias}",
                defaults: new { controller = "Article", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
               name: "CheckOut",
               url: "thanh-toan",
               defaults: new { controller = "ShoppingCart", action = "CheckOut", alias = UrlParameter.Optional },
               namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
                name: "ShoppingCart",
                url: "gio-hang",
                defaults: new { controller = "ShoppingCart", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
                name: "CategoryProduct",
                url: "danh-muc-san-pham/{alias}-{id}",
                defaults: new { controller = "Products", action = "ProductCategory", id = UrlParameter.Optional },
                namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
                name: "detailProduct",
                url: "chi-tiet/{alias}-{id}",
                defaults: new { controller = "Products", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
                 name: "Products",
                 url: "san-pham",
                 defaults: new { controller = "Products", action = "Index", alias = UrlParameter.Optional },
                 namespaces: new[] { "DoAnWeb.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"DoAnWeb.Controllers"}
            );
        }
    }
}
