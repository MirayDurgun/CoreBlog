using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "deneme@gmail.com";
            var values = mm.GetInboxByWriter(p);
            return View(values);
        }

    }
}
