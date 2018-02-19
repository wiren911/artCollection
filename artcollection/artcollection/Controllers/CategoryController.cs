using ArtCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtCollection.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index(string id)
        {
            var cats = db.Categories.Where(x => x.catCreatedBy.Id == id).ToList();
            return View(new CategoryViewModel { Id = id, Categories = cats });
        }
        public ActionResult Create(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
    public class CategoryViewModel
    {
        public string Id { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}