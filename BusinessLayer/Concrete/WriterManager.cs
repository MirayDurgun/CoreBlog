﻿using System;
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
		IWriterDal _writerDal;
		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public Writer GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Writer> GetList()
		{
			throw new NotImplementedException();
		}

		public List<Writer> GetWriterByID(int id)
		{
			return _writerDal.GetListAll(x => x.WriterID == id);
			//idye eşit olan değerleri ister
		}

		public void TAdd(Writer t)
		{
			_writerDal.Insert(t);
		}

		public void TDelete(Writer t)
		{
			_writerDal.Delete(t);
		}

		public void TUpdate(Writer t)
		{
			_writerDal.Update(t);
		}
        public Writer TGetById(int id)
        {
			return _writerDal.GetById(id);
        }
    }
}
