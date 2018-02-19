using ArtCollection.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtCollection.Controllers
{
    public class ImageController : BaseController
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileUpload()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult FileUpload( HttpPostedFileBase file, ImageViewModel img)
        //{
        //    if (file != null && file.ContentType.Contains("image"))
        //    {
        //        int FileSize = file.ContentLength;
        //        string FileName = file.FileName;
        //        string 
        //    }
        //    return View();
        //}
    }
}