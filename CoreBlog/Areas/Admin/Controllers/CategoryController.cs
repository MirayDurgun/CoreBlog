using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;


namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    //Area olduğunu controllera bildirmek gerekiyor
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(int page = 1)
        //Başlangıç değeri 1 olsun
        {
            var values = cm.GetList().ToPagedList(page, 3);
            //ToPagedList 2 parametre alır
            //1. sayfalama işlemi kaçıncı sayfadan başlasın (page 1 olarak yazmıştık 1'den başlar)
            //2. pagesize -> her sayfada kaç değer olacak? bizde 3 olarak belirledik
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);

            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");

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
        public IActionResult CategoryDelete(int id)
        {
            var categoryvalue = cm.GetById(id);
            //blogvalue t(generic)ye karşılık gelir
            //önce silinecek değeri bul
            cm.TDelete(categoryvalue);
            //sonra sil
            //blogvalue gönderilen idye karşılık gelen satırın tamamnı hafızaya alır
            return View(categoryvalue);
        }
    }
}
