using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminMessageController : Controller
    {

        Message2Manager mm2 = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();

        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm2.GetInboxByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm2.GetSendboxByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 message2)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            message2.SenderID = writerID;
            //message2.ReceiverID=2;
            message2.MessageStatus = true;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            mm2.TAdd(message2);
            return RedirectToAction("SendBox");
        }
    }
}
