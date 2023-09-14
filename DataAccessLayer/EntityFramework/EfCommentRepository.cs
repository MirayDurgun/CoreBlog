using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var c = new Context()) //Contexti c olarak belirttik
            {
                return c.Comments.Include(x => x.Blog).ToList();
                //Include otomatik usinglenmezse ctrl . ile vs.. yukarıya using Microsoft.EntityFrameworkCore; yazıyoruz
                //Include(x => x.Blog).ToList(); kodunun bu kısmında hangi entity Include içine dahil edilecekse yazılır.

            }
        }
    }
}
