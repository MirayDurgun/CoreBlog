using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;
        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void Delete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public Message2 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetInboxByWriter(int id)
        {
            return _message2Dal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetListAll()
        {
            return _message2Dal.GetListAll();
        }

        public List<Message2> GetListAll(Expression<Func<Message2, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void Update(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
