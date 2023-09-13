using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        //manageri çağırıp usingledik
        //adına cm verdik
        //IcategoryDal'ı karşılayacak bir değer tanımlamalıyız bu nedenle 
        //(new EfCategoryRepository()); tanımladık.
        public IActionResult Index()
        {
            var values = cm.GetList();
            //cm. içindeki bütün metotlara erişim sağlayabiliriz
            //GetAllCategories hepsini getir.
            return View(values);
            //geriye valuesi döndür
        }
    }
}
