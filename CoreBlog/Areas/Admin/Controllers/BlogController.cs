using ClosedXML.Excel;
using CoreBlog.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        [Area("Admin")]


        //BLOG LİSTESİ HAZIRLANMASI
        //STATİK
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //Tablo adı istiyor denebilir
                worksheet.Cell(1, 1).Value = "Blod ID";
                //Cell(1,1) 1.satır 1.sütun demek
                worksheet.Cell(1, 2).Value = "Blod Adı";
                //Cell(1,1) 1.satır 2.sütun demek


                int BlogRowCount = 2; //satır değerinin başlangıç değeri 2
                foreach (var item in GetBlogList()) //bu foreachte GetBlogList değerini bir metottan alması gerek
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    //BlogRowCount,1 .BlogRowCount ile gönderdiğim satırın 1. sütununa

                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma.xlsx");
                    //excelin döküman formatlarının olduğu web sitesi
                }
            }
        }
        public List<BlogModel> GetBlogList() //değeri karşılamak için list oluşturduk
        {
            List<BlogModel> bm = new List<BlogModel>
            { new BlogModel
            { ID = 1, BlogName = "C# Programlamaya Giriş" },
                new BlogModel { ID = 2, BlogName = "Tesla Firmasının Araçları" },
                new BlogModel { ID = 3, BlogName = "Corona Türkiye'de" }
            };
            return bm;
        }

        //VERİLERİN LİSTELENMESİ
        public IActionResult BlogListExcel()
        {
            return View();
        }

        //DİNAMİK HALE GETİRME
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //Tablo adı istiyor denebilir
                worksheet.Cell(1, 1).Value = "Blod ID";
                //Cell(1,1) 1.satır 1.sütun demek
                worksheet.Cell(1, 2).Value = "Blod Adı";
                //Cell(1,1) 1.satır 2.sütun demek


                int BlogRowCount = 2; //satır değerinin başlangıç değeri 2
                foreach (var item in BlogTitleList()) //bu foreachte GetBlogList değerini bir metottan alması gerek
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    //BlogRowCount,1 .BlogRowCount ile gönderdiğim satırın 1. sütununa

                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma.xlsx");
                    //excelin döküman formatlarının olduğu web sitesi
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm2 = new List<BlogModel2>();
            using (var c = new Context())
            {
                bm2 = c.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle

                }).ToList();
            }
            return bm2;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
