using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication19
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "getallproduct",
              url: "san-pham/all",
              defaults: new { controller = "Home", action = "GetAllProduct", id = UrlParameter.Optional, seourl = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "GetAllProductByCate",
                url: "danh-muc/{id}/{seourl}",
                defaults: new { controller = "Home", action = "GetAllProductByCate", id = UrlParameter.Optional, seourl = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Prodetail",
             url: "san-pham/{id}/{seourl}",
             defaults: new { controller = "Home", action = "Prodetail", id = UrlParameter.Optional, seourl = UrlParameter.Optional }
         );

            routes.MapRoute(
               name: "ArticleDetail",
               url: "bai-viet/{id}/{seourl}",
               defaults: new { controller = "Home", action = "ArticleDetail", id = UrlParameter.Optional, seourl = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
