using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		//partial oluşturarakta yapılabilir
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = bm.GetLast3Blog();
			return View(values);
		}
	}
}
