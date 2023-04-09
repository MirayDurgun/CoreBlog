using System;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
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
			var values = bm.GetBlogById(id);
			return View(values);
		}
		public IActionResult BlogListByWriter()
		{
			//writer idye göre getirir
			var values = bm.GetBlogListByWriter(1);
			return View(values);
		}
		[HttpGet]
		public IActionResult BlogAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult BlogAdd(Blog p)
		{
			BlogValidator bv = new BlogValidator();
			ValidationResult results = bv.Validate(p);

			if (results.IsValid)
			{
				p.BlogStatus = true; //false yaparak admine onaylatabiliriz
				p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToLongDateString());
				p.WriterID = 1;
				bm.TAdd(p);
				return RedirectToAction("BlogListByWriter", "Blog");


			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
