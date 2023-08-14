using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreBlog.ViewComponents.Writer
{
	public class WriterAboutOnDashboard:ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		public IViewComponentResult Invoke()
		{
			var values = writerManager.GetWriterByID(1);
			return View(values);
		}
	}
}
