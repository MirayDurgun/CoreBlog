using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IWriterService
	{
		//sadece ekleme işlemi gerçekleştireceğiz kayıt olma işlemi için
		void WriterAdd(Writer writer);
	}
}
