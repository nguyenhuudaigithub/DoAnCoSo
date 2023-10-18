using DoAnWeb.Models;
using DoAnWeb.Models.EF;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CategoryController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = dbContext.Categories;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.createddate= DateTime.Now;
                model.modifierdate= DateTime.Now;
                model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);
                dbContext.Categories.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = dbContext.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Attach(model);
                model.modifierdate = DateTime.Now;
                model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);
                dbContext.Entry(model).Property(x => x.title).IsModified = true;
                dbContext.Entry(model).Property(x => x.description).IsModified = true;
                dbContext.Entry(model).Property(x => x.link).IsModified = true;
                dbContext.Entry(model).Property(x => x.alias).IsModified = true;
                dbContext.Entry(model).Property(x => x.seokeywords).IsModified = true;
                dbContext.Entry(model).Property(x => x.seotitle).IsModified = true;
                dbContext.Entry(model).Property(x => x.seodescription).IsModified = true;
                dbContext.Entry(model).Property(x => x.position).IsModified = true;
                dbContext.Entry(model).Property(x => x.modifierdate).IsModified = true;
                dbContext.Entry(model).Property(x => x.modifierby).IsModified = true;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item=dbContext.Categories.Find(id);
            if(item!=null)
            {
                var DeleteItem=dbContext.Categories.Attach(item);
                dbContext.Categories.Remove(item);
                dbContext.SaveChanges();
                return Json(new {success=true });
            }
            return Json(true);
        }
    
    }
}