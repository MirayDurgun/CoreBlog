using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{

	public class WriterController : Controller
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult WriterMail()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}
		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		[AllowAnonymous]
        public IActionResult WriterEditProfile()
		{
			var writervalues = wm.GetWriterByID(1);
			return View(writervalues);
		}



    }
}
