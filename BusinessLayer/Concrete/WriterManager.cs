using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class WriterManager : IWriterService
	{
		IWriterDal _managerDal;
		public WriterManager(IWriterDal managerDal)
		{
			_managerDal = managerDal;
		}
		public void WriterAdd(Writer writer)
		{
			_managerDal.Insert(writer);
		}
	}
}
