using ArtCollection.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ArtCollection.Models.ApplicationUser;

namespace ArtCollection.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            var loggedInUser = User.Identity.Name;
            if (User.Identity.IsAuthenticated)
            {
                var user = db.Users.Single(x => x.UserName == loggedInUser);
                var posts = db.Posts.Where(x => x.CreatedBy.UserName == user.UserName).ToList();
                
                return View(new ProfileModelView(user, posts));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public ActionResult Image()
        {
            var db = new ApplicationDbContext();
            var loggedInUser = User.Identity.Name;
            var loadPicture = db.Users.Single(x => x.UserName == loggedInUser);
            if (loadPicture.FileName != null)
            {
                return File(loadPicture.Picture, loadPicture.ContentType);
            }
            else
            {
                return File("~/pictures/male.png", "image/png");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentType.Contains("image"))
                    {
                        var filepic = new Image
                        {
                            FileName = file.FileName,
                            ContentType = file.ContentType
                        };
                        using (var reader = new BinaryReader(file.InputStream))
                        {
                            filepic.Picture = reader.ReadBytes(file.ContentLength);
                        }                        
                    }
                    db.SaveChanges();
                    return RedirectToAction("About", "Home");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save file to databse, please try again!");
                throw;
            }
            return View();
        }

        public ActionResult SeeAllCategories(string id)
        {
            var user = db.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                var realUser = User.Identity.Name;
                var caties = db.Categories.SingleOrDefault(x => x.catCreatedBy.Id == id && x.catCreatedBy.UserName == realUser);

                var post = db.Posts.Where(x => x.CreatedBy.UserName == user.UserName).ToList();
                var send = new ProfileModelView(user, post);
                return View(send);

            }
            else
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View();
        }

        public ActionResult CreatePost(string id)
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class ProfileModelView
    {
        public ApplicationUser User { get; set; }
        public ICollection<Post> Posts { get; set; }

        public ProfileModelView(ApplicationUser u, ICollection<Post> p)
        {
            this.User = u;
            this.Posts = p;
        }
    }

}