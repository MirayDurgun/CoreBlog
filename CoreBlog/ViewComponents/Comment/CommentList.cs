using System.Collections.Generic;
using CoreBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
            UserName="Umut"
                },
                new UserComment
                {
                    ID=2,
            UserName="Miray"
                },
                new UserComment
                {
                    ID=3,
            UserName="Kaan"
                }
            };
            return View(commentvalues);
        }
    }
}
