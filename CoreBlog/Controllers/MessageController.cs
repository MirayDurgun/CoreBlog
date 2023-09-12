using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm2 = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 1;
            var values = mm2.GetInboxByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm2.GetById(id);
            return View(value);
        }
    }
}
