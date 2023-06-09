﻿using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CoreBlog.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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
			var values = bm.GetListWithCategoryByWriterBm(1);
			return View(values);
		}
		[HttpGet]
		public IActionResult BlogAdd()
		{
			List<SelectListItem> categoryvalues = (from x in cm.GetList()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.cv = categoryvalues;

			return View();
			//viewbag sayesinden category valuesten gelen değereleri 
			//dropdowna taşıyacak

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
		public IActionResult DeleteBlog(int id)
		{
			var blogvalue = bm.GetById(id);
			//blogvalue t(generic)ye karşılık gelir
			//çnce silinecek değeri bul
			bm.TDelete(blogvalue);
			//sonra sil
			//blogvalue gönderilen idye karşılık gelen satırın tamamnı hafızaya alır
			return RedirectToAction("BlogListByWriter");
		}
		[HttpGet]
		public IActionResult EditBlog(int id)
		{
			var blogvalue = bm.GetById(id);
			List<SelectListItem> categoryvalues = (from x in cm.GetList()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.cv = categoryvalues;
			//viewbag sayesinden category valuesten gelen değereleri 
			//dropdowna taşıyacak
			return View(blogvalue);
		}
		[HttpPost]
		public IActionResult EditBlog(Blog p)
		{
			var blogValue = bm.GetById(p.BlogID);
			p.BlogStatus = true;
			p.BlogCreateDate = DateTime.Parse(blogValue.BlogCreateDate.ToShortDateString());
			p.WriterID = 1;
			bm.TUpdate(p);
			return RedirectToAction("BlogListByWriter");
		}

	}

}

