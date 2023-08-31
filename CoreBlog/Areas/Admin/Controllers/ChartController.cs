using CoreBlog.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index() //kategorilerin grafik üzerinde listeleneceği yer
        {
            return View();
        }
        public IActionResult CategoryChart() //verilere string değer atamama yardımcı olan yer
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Siber Güvenlik",
                categorycount = 6
            });
            return Json(new { jsonlist = list });
            //jsonla döndüreceğiz çünkü chartları json formatında scriptle çağıracağız
        }
    }
}
