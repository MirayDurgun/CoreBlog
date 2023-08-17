using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    //bağlantı adresi tanımlanacak bu kısımda
    public class Context : DbContext  /*DbContext clasından miras alıyor
                                      DbContext sınıfını kullanabilmek için EntityFrameworkCore paketi dahil edilmeli*/
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //2 şekilde bağlantı kurulur 
            //1.
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; database=CoreBlogDb; integrated security=true;");//2 adet ters slaş olmalı
                                                                                                                          //2.
                                                                                                                          // optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB; database=CoreBlogDb; integrated security=true;");
            /*Bu şekilde de bağlantı sağlanabilir, connectionString  hangi ana makine'ye bağlantı yapılacağını,
            o ana makinedeki hangi veritabanına bağlanacağımızı, o veritabanına bağlanmak için gerekli olan
            kullanıcı adı ve şifresi gibi bilgilerin tutulduğu bir kod parçasıdır.*/

        }
        public DbSet<About> Abouts { get; set; } //veritababnında tabloda isimler about yerine abouts oalrak görünecek. karışmaması için
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

