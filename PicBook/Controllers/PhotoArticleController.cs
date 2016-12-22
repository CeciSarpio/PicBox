using Microsoft.AspNet.Identity.Owin;
using PicBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PicBook.Controllers
{
    public class PhotoArticleController : Controller
    {
        // GET: PhotoArticle
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var articles = database.PhotoArticles.Include(a => a.Author).ToList();
                return View(articles);
            }
        }
        public ActionResult Yourlist()
        {
            using (var database = new BlogDbContext())
            {
               var articles = database.PhotoArticles.Include(a => a.Author).ToList();
               return View(articles);
            }
        }
        public ActionResult Create()
        {
            return View();
        }


        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Image")]PhotoArticle article)
        {
            using (var db = new BlogDbContext())
            {
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["Image"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                article.Image = imageData;
                var user = db.Users.FirstOrDefault(u => u.UserName.Equals(this.User.Identity.Name));
                article.AuthorId = user.Id;
                db.PhotoArticles.Add(article);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            
        }
    }
}