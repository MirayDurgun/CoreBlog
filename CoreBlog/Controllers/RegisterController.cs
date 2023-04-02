using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
		//kayıt olanlar writera yazar olarak kaydolacak bu nedenle write çağırdık
		//

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer p)
		{
			p.WriterStatus = true;
			p.WriterAbout = "Deneme Test";
			wm.WriterAdd(p); //parametreden gelen değeri wm içine ekler
			return RedirectToAction("Index", "Blog");

			//RedirectToAction sadece proje içi yönlendirma yapmak için kullanılır
			//Index'e git indexte blog controller içinde
			//kayıt olduktan sonra bizi blog sayfasına atacak
			//return view(); kullansaydık kayıt olduktan sonra yeniden kayıt ol sayfasına atacaktı 
		}
	}
}

