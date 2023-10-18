using CKFinder.Settings;
using DoAnWeb.Models;
using DoAnWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWeb.Areas.Admin.Controllers
{
   [Authorize(Roles = "Admin,Employee")]

    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Product
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
        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "id", "title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<String> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {

                        if (i + 1 == rDefault[0])
                        {
                            model.image = Images[i];
                            model.ProductImage.Add(new ProductImage()
                            {
                                productid = model.id,
                                image = Images[i],
                                isdefault = true
                            });

                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage()
                            {
                                productid = model.id,
                                image = Images[i],
                                isdefault = false
                            });
                        }
                    }
                }
                model.createddate = DateTime.Now;

                model.modifierdate = DateTime.Now;
                if (string.IsNullOrEmpty(model.alias))
                {
                    model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);
                }
                //model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);
                if (string.IsNullOrEmpty(model.seotitle))
                {
                    model.seotitle = model.title;
                }
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "id", "title");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "id", "title");
            var item = db.Products.Find(id);
            var productImages = db.ProductImages.Where(pi => pi.productid == id).ToList();
            ViewBag.ProductImages = productImages;
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                model.modifierdate = DateTime.Now;
                model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);

                // Update existing product images
                var existingImages = db.ProductImages.Where(pi => pi.productid == model.id).ToList();
                for (int i = 0; i < existingImages.Count; i++)
                {
                    var image = existingImages[i];
                    image.image = Images[i];
                    image.isdefault = (i + 1 == rDefault[0]);
                }

                // Add new product images
                for (int i = existingImages.Count; i < Images.Count; i++)
                {
                    var image = new ProductImage
                    {
                        productid = model.id,
                        image = Images[i],
                        isdefault = (i + 1 == rDefault[0])
                    };
                    db.ProductImages.Add(image);
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "id", "title");
            return View(model);
        }



        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    var item = db.Products.Find(id);
        //    if (item != null)
        //    {
        //        var checkImg = item.ProductImage.Where(x => x.productid == item.id);
        //        if (checkImg != null)
        //        {
        //            foreach (var img in checkImg)
        //            {
        //                db.ProductImages.Remove(img);
        //                db.SaveChanges();
        //            }
        //        }
        //        db.Products.Remove(item);
        //        db.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    return Json(new { success = false });
        //}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.isactive = !item.isactive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isactive = item.isactive });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.ishome = !item.ishome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, ishome = item.ishome });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.issale = !item.issale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, issale = item.issale });
            }
            return Json(new { success = false });
        }
       

        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            db.ProductImages.Add(new ProductImage
            {
                productid = productId,
                image = url,
                isdefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult DeleteImages(int id)
        {
            var item = db.ProductImages.Find(id);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}