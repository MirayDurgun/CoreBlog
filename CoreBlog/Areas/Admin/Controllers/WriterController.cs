using CoreBlog.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            //SerializeObject = serileştirme
            //nesnelerin çalışma zamanındaki (runtime) durumlarını alıp geçici veya kalıcı olarak bir kaynağa (file,memory, database, socket, buffer vb.) saklamak/transfer etmek için belirli bir forma dönüştürülüp yazma işlemidir.
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Ayşe"
            },
            new WriterClass
            {
                 Id=2,
                 Name="Ahmet"
            },
            new WriterClass
            {
                Id=3,
                Name="Fatma"
            }

        };
    }
}
