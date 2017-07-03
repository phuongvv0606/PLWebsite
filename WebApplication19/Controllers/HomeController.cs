using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class HomeController : Controller
    {
        plEntities db = new plEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSlider()
        {
            return PartialView(db.Images.OrderByDescending(m => m.Id).Where(m => m.Types == (int)Types.IMAGE.SLIDER).ToList());
        }
        public ActionResult GetMenu()
        {
            return PartialView(db.Menus.OrderBy(m => m.Pioriti).ToList());
        }
        public ActionResult GetHomePageSevice()
        {
            return PartialView(db.Products.
                OrderByDescending(m => m.Id).
                Where(m => m.CateId == (int)Types.Category.SEVICE).
                Take(4).ToList());
        }
        public ActionResult GetTopHomeProduct()
        {
            return PartialView(db.Products.
                OrderByDescending(m => m.Pioriti).
                Where(m => m.CateId == (int)Types.Category.PRODUCT).
                Where(m=>m.Status==(int)Types.Status.DISPLAY).
                Take(9).ToList()); 
        }
        public ActionResult AboutHomePage()
        {
            return PartialView();
        }
        
    }
}