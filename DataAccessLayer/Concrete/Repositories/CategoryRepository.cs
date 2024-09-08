using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();          //Context sınıfından bir nesne türettik. Direkt işlemimizin veri tabanına işlemesi için
        DbSet<Category> _object;            //Kategori sınıfının değerlerini tutar. Yani yeni bir categori kısmı(ad, id vb.)

        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _object.Add(p);         //Categori tablosuna yeni kayıt eklemeyi ifade eder.
            c.SaveChanges();        //Değişiklikleri kaydeder.
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
