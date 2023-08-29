using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();
            return View();

        }
    }
}
