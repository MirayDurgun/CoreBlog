using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());

		public IViewComponentResult Invoke(int id)
		{
			var values = cm.GetList(id);
			//Comment Manager'da GetList BlogId==id
			//olduğundan parantez içine rakam yazarsak blog id'ye göre getirir.
			return View(values);
		}
	}
}
