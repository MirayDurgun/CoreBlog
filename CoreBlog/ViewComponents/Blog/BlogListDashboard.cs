using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Blog
{
	public class BlogListDashboard:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke(int id)
		{
            var userName = User.Identity.Name;
            ViewBag.name = userName;
            var values = bm.GetBlogListWithCategory();
			return View(values);
		}
	}
}
