using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(Article model)
        {
            using (var database = new BlogDbContext())
            {
                var comment = new Comment();
                comment.Id = model.Id;

                return View(comment);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Comment comment)
        {
            using (var database = new BlogDbContext())
            {
                var opinion = new Comment(comment.Id, comment.Content);

                database.Comments.Add(opinion);
                database.SaveChanges();

                return RedirectToAction("Details", "Article", new {@id = comment.Id });
            }
        }

        public ActionResult List(int? id)
        {

            using (var database = new BlogDbContext())
            { 
            var coments = database.Comments.ToList();
          
            return View(coments);
            }
        }

        [HttpGet]
        public ActionResult Delete(Comment index)
        {

                return View(index);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            using (var database = new BlogDbContext())
            {
                var comment = database.Comments.FirstOrDefault(c => c.Id == id);

                database.Comments.Remove(comment);
                database.SaveChanges();

                return RedirectToAction("List", "Article");
            }
        }
    }
}