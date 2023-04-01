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

namespace DataAccessLayer.EntityFramwork
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context()) //Contexti c olarak belirttik
            {
                return c.Blogs.Include(x => x.Category).ToList();
                //Include otomatik usinglenmezse ctrl . ile vs.. yukarıya using Microsoft.EntityFrameworkCore; yazıyoruz
                //Include(x => x.Category).ToList(); kodunn bu kısmında hangi entity Include içine dahil edilecekse yazılır.

            }

        }

    }
}
