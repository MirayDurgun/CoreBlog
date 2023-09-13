using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        [Area("Admin")]
        public IActionResult Inbox()
        {
            return View();
        }
        public IActionResult SendBox()
        {
            return View();
        }
    }
}
