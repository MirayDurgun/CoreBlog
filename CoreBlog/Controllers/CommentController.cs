using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToString());
            comment.CommentStatus = true;
            comment.BlogID = comment.CommentID;
            cm.CommentAdd(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            //idye göre işlem gerçekleştireceğiz
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
