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
               Where(m => m.HomePage == true).
                Where(m => m.Status == (int)Types.Status.DISPLAY).
                Take(9).ToList());
        }
        public ActionResult AboutHomePage()
        {
            return PartialView(db.Articles.OrderByDescending(m => m.Id).
                Where(m => m.CateId == (int)Types.Article.ABOUT).FirstOrDefault());
        }
        public ActionResult GetAllProduct()
        {
            var totalitem = db.Products.Where(m => m.Status == (int)Types.Status.DISPLAY).Count();
            var totalpage = 0;
            if (totalitem % 30 == 0)
            {
                totalpage = totalitem / 30;
            }
            else
            {
                totalpage = (totalitem / 30) + 1;
            }
            ViewBag.totalpage = totalpage;
            return View();
        }
        public ActionResult ProductPaging(int page)
        {
            var products = db.Products
                .OrderByDescending(m => m.Id)
                .Where(m => m.Status == (int)Types.Status.DISPLAY)
                .Skip(30 * (page - 1))
                .Take(30).ToList();
            return PartialView(products);
        }
        public ActionResult GetHomeCustomer()
        {
            return PartialView(db.Articles.OrderByDescending(m => m.Id).
                Where(m => m.CateId == (int)Types.Article.CUSTOMER).Take(3).ToList());
        }
        public ActionResult Prodetail(int id)
        {
            var product = db.Products.Where(m => m.Id == id).FirstOrDefault();
            return View(product);
        }
        public ActionResult GetProductParentCate()
        {
            var cate = (from c in db.Categories
                        where c.ParentId == (int)Types.Category.PRODUCT
                         && c.Status == (int)Types.Status.DISPLAY
                        orderby c.Pioriti descending
                        select c).ToList();
            return PartialView(cate);
        }
        [ChildActionOnly]
        public PartialViewResult GetProductChidCate(int id)
        {
            var cate = (from c in db.Categories
                        where c.ParentId == id
                         && c.Status == (int)Types.Status.DISPLAY
                        orderby c.Pioriti descending
                        select c).ToList();

            return PartialView(cate);
        }
        public ActionResult GetProductImage(int id)
        {
            var img = db.Images.Where(m => m.ParentId == id).Where(m => m.Types == (int)Types.IMAGE.PRODUCT).ToList();
            return PartialView(img);
        }
        public ActionResult ArticleDetail(int id)
        {
            var article = db.Articles.Where(m => m.Id == id).FirstOrDefault();

            return View(article);
        }
        public ActionResult GetWebLogo()
        {
            var logo = db.SystemConfigs.Where(m => m.Id == (int)Types.SystemConfig.LOGO).FirstOrDefault();
            return PartialView(logo);
        }
        public ActionResult GetPageAddress()
        {
            var logo = db.SystemConfigs.Where(m => m.Id == (int)Types.SystemConfig.ADDRESS).FirstOrDefault();
            return PartialView(logo);
        }
        public ActionResult GetAllProductByCate(int id)
        {
            var cate = db.Categories.Where(m => m.Id == id).FirstOrDefault();

            var totalitem = db.Products.
                Where(m => m.Status == (int)Types.Status.DISPLAY).
                Where(m => m.CateId == id).Count();
            var totalpage = 0;
            if (totalitem % 30 == 0)
            {
                totalpage = totalitem / 30;
            }
            else
            {
                totalpage = (totalitem / 30) + 1;
            }
            ViewBag.totalpage = totalpage;
            return View(cate);
        }
        public ActionResult ProductByCatePageing(int page, int id)
        {
            var products = db.Products
                  .OrderByDescending(m => m.Id)
                  .Where(m => m.Status == (int)Types.Status.DISPLAY)
                  .Where(m => m.CateId == id)
                  .Skip(30 * (page - 1))
                  .Take(30).ToList();
            return PartialView("ProductPaging", products);

        }
        public ActionResult SameCateProduct(int cateid, int proid)
        {
            var data = db.Products.
                Where(m => m.CateId == cateid).
            Where(m => m.Id != proid).OrderByDescending(m => m.Id).Take(6).ToList();
            return PartialView("ProductPaging", data);
        }
        public ActionResult GetAllNews()
        {
            var totalitem = db.Articles.
                Where(m => m.CateId == (int)Types.Category.NEWS).
               Where(m => m.Status == (int)Types.Status.DISPLAY).Count();
            var totalpage = 0;
            if (totalitem % 30 == 0)
            {
                totalpage = totalitem / 30;
            }
            else
            {
                totalpage = (totalitem / 30) + 1;
            }
            ViewBag.totalpage = totalpage;
            return View();
        }
        public ActionResult NewsPaging(int page)
        {
            var data = db.Articles.
                Where(m => m.CateId == (int)Types.Category.NEWS).
               Where(m => m.Status == (int)Types.Status.DISPLAY).OrderByDescending(m => m.Id)
               .Skip(30 * (page - 1))
                  .Take(30).ToList();
            return PartialView(data);
        }

        public ActionResult TopSupport()
        {


            var data = db.Supports.Where(m => m.WebPositions == (int)Types.Support.TOP).ToList();
            return PartialView(data);
        }
        public ActionResult BottomSupport()
        {
            var data = db.Supports.Where(m => m.WebPositions == (int)Types.Support.BOTTOM).ToList();
            return PartialView(data);
        }
        public ActionResult ConfirmOrder(int id)
        {
            var data = db.Products.Where(m => m.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}