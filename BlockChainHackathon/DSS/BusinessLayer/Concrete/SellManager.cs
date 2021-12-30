using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SellManager : ISellService
    {
        ISellDal _sellDal;

        public SellManager(ISellDal sellDal)
        {
            _sellDal = sellDal;
        }

        public void SellAdd(Sell sell)
        {
            _sellDal.Insert(sell);
        }

        public void SellDelete(Sell sell)
        {
            _sellDal.Delete(sell);
        }

        public void SellUpdate(Sell sell)
        {
            _sellDal.Update(sell);
        }

        public Sell GetByID(int id)
        {
            return _sellDal.Get(x => x.SellID == id);
        }

        public List<Sell> GetList()
        {
            return _sellDal.List();
        }   
    }
}
