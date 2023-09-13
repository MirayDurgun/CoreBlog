using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {


        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
                //Bu komut, bir kaynak dosyasına başka bir dosyanın içeriğini dahil etmek için kullanılır.
                //Message2s tablosundaki her bir kayıt için ilişkili ReceiverUser nesnesini de alır
                //ReceiverID alanı belirli bir id ile eşleşen tüm mesajları seçer
            }
        }
        public List<Message2> GetListWithMessageBySender(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.ReveiverUser).Where(y => y.SenderID == id).ToList();
            }
        }
    }
}
