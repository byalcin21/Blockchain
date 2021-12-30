using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    //T = Hangi tabloyu gönderirsem üzerinde çalışıyorum.
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);

        //İd'ye göre kullanıcı bulma.
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T p);
        void Update(T p);

        //Şartlı Listeleme için kullanacağız.
        //Bu method yazarlar içierisinde Ali olan yazarları getirir.
        List<T> List(Expression<Func<T, bool>> filter);
    }
}