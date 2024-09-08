using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        Context c = new Context();          //Context sınıfından bir nesne türettik. Direkt işlemimizin veri tabanına işlemesi için
        DbSet<T> _object;                   //Kategori sınıfının değerlerini tutar. Yani yeni bir categori kısmı(ad, id vb.)
        public GenericRepository()          //Constructor metodu, bir sınıfın örneği oluşturulduğunda otomatik olarak çağrılarak nesnenin başlangıç değerlerini ayarlayan özel bir yöntemdir
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);         //entity state komutu kullanarak silme işlemini gerçekleştirdik.
            deletedEntity.State = EntityState.Deleted;
           // _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)  
        {
            return _object.SingleOrDefault(filter);          // sadece tek bir değer döndürmek istersek bunu kullanırız. Listeden farkı budur.
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);  //üstteki komutu kullandığımız için buna ihtiyacımız kalmadı. 
            c.SaveChanges();                //veri tabanına kaydetmeyi sağlar.
        }

        public List<T> List()
        {
            return _object.ToList();            //bu kısımda veri tabanında başka bir adda var diye hata veriyor anlamadım 1 sn
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
