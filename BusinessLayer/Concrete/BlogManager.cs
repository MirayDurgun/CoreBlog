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
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;
		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public void BlogAdd(Blog blog)
		{
			_blogDal.Insert(blog);
		}

		public void BlogDelete(Blog blog)
		{
			_blogDal.Delete(blog);
		}

		public void BlogUpdate(Blog blog)
		{
			_blogDal.Update(blog);
		}

		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.BlogID == id);
			//idye eşit olan değerleri ister
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public Blog GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}
	}
}
