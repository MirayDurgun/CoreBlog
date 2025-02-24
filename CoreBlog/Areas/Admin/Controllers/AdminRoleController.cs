﻿using CoreBlog.Areas.Admin.Models;
using CoreBlog.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]//Rolü admin ve Moderator olanlar erişsin
	public class AdminRoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddRole(RoleViewModel rolemodel)
		{
			if (ModelState.IsValid)
			{
				AppRole role = new AppRole
				{
					Name = rolemodel.name
				};

				var result = await _roleManager.CreateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			return View(rolemodel);
		}

		[HttpGet]
		public IActionResult UpdateRole(int id)
		{
			var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			RoleUpdateViewModel model = new RoleUpdateViewModel
			{
				Id = values.Id,
				name = values.Name
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
		{
			var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();
			values.Name = model.name;
			var result = await _roleManager.UpdateAsync(values);
			//await kullanacağımız zaman metot async olmalı
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			return View(model);
		}

		public async Task<IActionResult> DeleteRole(int id)
		{
			var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			var result = await _roleManager.DeleteAsync(values);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			return View(result);
		}

		public async Task<IActionResult> UserRoleList()
		{
			var values = _userManager.Users.ToList();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> AssingRole(int id)
		{
			//hem kullanıcıları hemde roleri listeleyip iki ayrı tablodan veri çekeceğiz
			var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
			var roles = _roleManager.Roles.ToList();
			TempData["UserId"] = user.Id; //roller tablosundaki bütün rolleri getirir

			var userRoles = await _userManager.GetRolesAsync(user);
			List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
			foreach (var item in roles)
			{
				RoleAssignViewModel m = new RoleAssignViewModel();
				m.RoleID = item.Id;
				m.Name = item.Name;
				m.Exists = userRoles.Contains(item.Name);
				model.Add(m);
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AssingRole(List<RoleAssignViewModel> model)
		{
			var userid = (int)TempData["UserId"];
			var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
			foreach (var item in model)
			{
				if (item.Exists) //item true isi tiki seçili ise şunları yap
				{
					await _userManager.AddToRoleAsync(user, item.Name);
					//Checkbox seçili olanları role tablosuna ekler
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.Name);
					//seçili olmayan değerleri listeden siler

				}
			}
			return RedirectToAction("UserRoleList");
		}
	}
}
