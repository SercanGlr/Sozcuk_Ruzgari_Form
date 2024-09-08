using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{   
    public class Context : DbContext
    {
        //burda db tablo isimleriyle burdaki propery isimleri aynı değil db kontrolü yaptıktan sonra bak
        public DbSet<About> Abouts { get; set; } // örneğin db'de tablo adı Abouts mu diye kontrol et bebim şimdi çıkmam gerekiyor tamam
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
