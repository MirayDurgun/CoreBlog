using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
        //dışarıdan entity parametresi gönderebilmek için <> sembolü eklenir.
        //T tanımladık, t burada entity'nin karşılığı olan bir değerdir.
        //where şartı yazıyoruz, gönderdiğimiz T (T : class) bir klasa ait bütün değerleri kullanacak.
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetListAll(); //void yok
						  //GetAll da yazılabilir
		T GetById(int id);  //dışarıdan id parametresi alır.
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
