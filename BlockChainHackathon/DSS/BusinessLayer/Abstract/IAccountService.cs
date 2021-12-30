using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAccountService
    {
        List<Account> GetList();
        void AccountAdd(Account account);
        //Kişiyi bulabilmek için ID'ye göre ara.
        Account GetByID(int id);
        //Kategor sınıfına dair nesne alıyoruz. Tüm Sql satırı
        void AccountDelete(Account account);
        //Generic Repository üzerinden yine almış olduğumuz nesne ile Update işlemi yapıyoruz.
        void AccountUpdate(Account account);
    }
}
