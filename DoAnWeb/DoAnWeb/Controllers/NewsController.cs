using DoAnWeb.Models;
using DoAnWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index(int? page)
        {
            var pageSize = 10;
            if(page == null) 
            {
               page = 1;
            }
            IEnumerable<News> items = db.News.OrderByDescending(x=>x.createddate).ToList();
            var pageIndex=page.HasValue ? page.Value : 1;
            items= items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Detail(int id)
        {
            var items = db.News.Find(id);
            return View(items);
        }
        public ActionResult Partial_News_Home()
        {
            var items = db.News.Take(5).ToList();
            return PartialView(items);
        }
    }
}