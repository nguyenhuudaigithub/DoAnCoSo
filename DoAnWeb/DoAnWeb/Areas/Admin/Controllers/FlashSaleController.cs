using DoAnWeb.Models;
using DoAnWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DoAnWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FlashSaleController : Controller
    {
        

        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Index(string SearchText, int? page)
        {
            var pageSize = 10;
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.alias.Contains(SearchText) || x.title.Contains(SearchText));
            }
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(items);

        }

        [HttpPost]
        public ActionResult IsFlashSale(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.isflashsale = !item.isflashsale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isflashsale = item.isflashsale });
            }
            return Json(new { success = false });
        }
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(TimeFLS model)
        {
            if (ModelState.IsValid)
            {
                var dl = db.TimeFLs.ToList();
                db.TimeFLs.RemoveRange(dl);
                model.createddate = DateTime.Now;
                model.modifierdate = DateTime.Now;
                db.TimeFLs.Add(model);
                db.SaveChanges();
                return RedirectToAction("setTime");
            }
            return View(model);
        }
        public ActionResult setTime(string SearchText, int? page)
        {
            var pageSize = 10;
            IEnumerable<TimeFLS> items = db.TimeFLs.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.ngayBD.ToString().Contains(SearchText) || x.ngayKT.ToString().Contains(SearchText));
            }
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(items);
        }

    }
}