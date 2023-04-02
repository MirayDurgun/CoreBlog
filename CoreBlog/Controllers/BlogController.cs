using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            //cm. içindeki bütün metotlara erişim sağlayabiliriz
            //GetAllCategories hepsini getir.
            return View(values);
            //geriye valuesi döndür
        }
		public IActionResult BlogReadAll(int id)
		{            
            //idye göre detayları getirecek

			ViewBag.i = id;
            var values=bm.GetBlogById(id);
            return View(values);
        }

	}
}
