using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = db.Categories;
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
            if(ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return  View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Categories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.ModifierDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Entry(model).Property(x=>x.Title).IsModified = true;
                db.Entry(model).Property(x=>x.Description).IsModified = true;
                db.Entry(model).Property(x=>x.Alias).IsModified = true;
                db.Entry(model).Property(x=>x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x=>x.SeoTitle).IsModified = true;
                db.Entry(model).Property(x=>x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x=>x.Position).IsModified = true;
                db.Entry(model).Property(x=>x.ModifierDate).IsModified = true;
                db.Entry(model).Property(x=>x.ModifierBy).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Categories.Find(id);
            if(item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.Categories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false }); ;
        }
    }
}