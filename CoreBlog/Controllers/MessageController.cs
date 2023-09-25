using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm2 = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm2.GetInboxByWriter(writerID);
            ViewBag.v1 = values.Count();
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm2.GetSendboxByWriter(writerID);
            ViewBag.v1 = values.Count();
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = mm2.GetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            {
                UserManager um = new UserManager(new EfUserRepository());
                List<SelectListItem> receiverUsers = (from x in um.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Email,
                                                          Value = x.Id.ToString()
                                                      }).ToList();
                ViewBag.v1 = receiverUsers;
                return View();
            }
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message2)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            message2.SenderID = writerID;
            // message2.ReceiverID = 2;
            message2.MessageStatus = true;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm2.TAdd(message2);
            return RedirectToAction("Inbox");
        }

        public IActionResult DeleteMessage(int id)
        {
            var messagevalue = mm2.GetById(id);
            mm2.TDelete(messagevalue);
            return RedirectToAction("Inbox");
        }
    }
}
