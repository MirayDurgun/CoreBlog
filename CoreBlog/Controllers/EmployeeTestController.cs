using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    public class EmployeeTestController : Controller
    {
        //Presentation katmanu üzerinden api datasını erişip CRUD işlemleri gerçekleştireceğiz
        //BlogApi'yi referans gösterdik
        public async Task<IActionResult> Index()
        {
            //göndermiş olduğumuz apinin adresinde(localhost) bulunan adrese istekte bulunacağız
            //ve bu isteğe karşılık gelen değerleri listeleyeceğiz
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(""); //adresi yaz!HTTP GET İsteği Gönderme
            var jsonString = await responseMessage.Content.ReadAsStringAsync(); //HTTP yanıtı okunuyor
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString); //JSON veri, belirtilen Class1 sınıfına uygun bir şekilde deserialize ediliyor.
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var rensonseMessage = await httpClient.PostAsync("", content);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var rensonseMessage = await httpClient.GetAsync("" + id);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await rensonseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var rensonseMessage = await httpClient.PutAsync("", content);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var rensonseMessage = await httpClient.DeleteAsync("" + id);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    /*DeserializeObject
        JSON verilerini bir .NET nesnesine dönüştürmeye olanak tanır.
      SerializeObject
       .NET nesnesini JSON verisine çevirir.
    */


    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
