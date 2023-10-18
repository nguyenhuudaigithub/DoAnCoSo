using DoAnWeb.Models;
using DoAnWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
   [Authorize(Roles = "Admin,Employee")]
    public class NewsController : Controller
    {
        private ApplicationDbContext db=new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index(string SearchText,int? page)          
        {
            IEnumerable<News> items = db.News.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.alias.Contains(SearchText)||x.title.Contains(SearchText));
            }
            var pageSize=5;
            if(page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items= items.ToPagedList(pageIndex,pageSize);
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(items);
        }
        public ActionResult add()

        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(News model)
        {
            if (ModelState.IsValid)
            {
                model.createddate = DateTime.Now;
                model.categoryid = 1;
                model.modifierdate = DateTime.Now;
                model.alias=DoAnWeb.Models.Common.Filter.FilterChar(model.title);
                db.News.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)

        {
            var item = db.News.Find(id);

            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                model.modifierdate = DateTime.Now;
                model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);
                db.News.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.News.Find(id);
            if (item != null)
            {
                db.News.Remove(item);
                db.SaveChanges();
                return Json(new {success=true});
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.News.Find(id);
            if (item != null)
            {
                item.isactive = !item.isactive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isactive = item.isactive });
            }
            return Json(new { success = false });
        }
    }
}