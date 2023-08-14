﻿using System.Linq;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
	public class DashBoardController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			Context c=new Context();
			ViewBag.v1=c.Blogs.Count().ToString();
			ViewBag.v2=c.Blogs.Where(x=>x.WriterID==1).Count();
			ViewBag.v3=c.Categories.Count();
			return View();
		}
		[AllowAnonymous]
		public IActionResult v()
		{
			return View();
		}
	}
}
