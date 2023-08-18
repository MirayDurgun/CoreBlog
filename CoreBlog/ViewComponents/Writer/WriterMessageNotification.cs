using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm2 = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = mm2.GetInboxByWriter(id);
            return View(values);
        }
    }
}
