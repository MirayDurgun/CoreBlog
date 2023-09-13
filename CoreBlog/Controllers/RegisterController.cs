using System.Collections.Generic;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using CoreBlog.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //var cities = new Cities();
            //cities.Sehirler = new List<SelectListItem>();
            //cities.Sehirler.Add(new SelectListItem() { Text = "İstanbul", Value = "1", Selected = false });
            //cities.Sehirler.Add(new SelectListItem() { Text = "Ankara", Value = "2", Selected = false });
            //cities.Sehirler.Add(new SelectListItem() { Text = "İzmir", Value = "3", Selected = false });
            //cities.Sehirler.Add(new SelectListItem() { Text = "Diğer", Value = "4", Selected = false });
            //return View(cities);
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            //validasyonların geçerliliğini kontrol etmek için
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);

            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.TAdd(p); //parametreden gelen değeri wm içine ekler
                return RedirectToAction("Index", "Blog");


                //RedirectToAction sadece proje içi yönlendirma yapmak için kullanılır
                //Index'e git indexte blog controller içinde
                //kayıt olduktan sonra bizi blog sayfasına atacak
                //return view(); kullansaydık kayıt olduktan sonra yeniden kayıt ol sayfasına atacaktı 
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

