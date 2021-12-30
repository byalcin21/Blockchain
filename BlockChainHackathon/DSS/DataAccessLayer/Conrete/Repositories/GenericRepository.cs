using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Conrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        //Constructor Kurucu Method
        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            //Silme işlemini Tercih Etmek Yerine Durumunu False Yapıyoruz.
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        //Normal List TÜm Değerleri Getir
        public List<T> List()
        {
            return _object.ToList();
        }
        //Seçili Filtreye Göre Getir
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
