using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace CoreBlog.ViewComponents.Writer
{
	public class WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		Context c = new Context();

		public IViewComponentResult Invoke()
		{
			var userMail = User.Identity.Name;
			var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
			var values = writerManager.GetWriterByID(writerID);
			return View(values);
		}
	}
}
