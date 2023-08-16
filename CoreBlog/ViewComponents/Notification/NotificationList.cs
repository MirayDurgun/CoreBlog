using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Notification
{
    public class NotificationList:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }
    }
}
