using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SoldManager : ISoldService
    {
        ISoldDal _soldDal;

        public SoldManager(ISoldDal soldDal)
        {
            _soldDal = soldDal;
        }

        public void SoldAdd(Sold sold)
        {
            _soldDal.Insert(sold);
        }

        public void SoldDelete(Sold sold)
        {
            _soldDal.Delete(sold);
        }

        public void SoldUpdate(Sold sold)
        {
            _soldDal.Update(sold);
        }

        public Sold GetByID(int id)
        {
            return _soldDal.Get(x => x.SoldID == id);
        }

        //Kullanıcının id'sine göre liste getir.
        public List<Sold> GetListMySold(int id)
        {
            return _soldDal.List(x => x.UserID == id);
        }

        public List<Sold> GetList()
        {
            return _soldDal.List();
        }
    }
}
