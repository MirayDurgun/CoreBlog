using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
		//kategoriyle beraber listeyi getir
		//kategori sadece blog ile bağlı (foreign key) olduğu için buraya tanımladık
		List<Blog> GetListWithCategoryByWriter(int id);
	}
}
