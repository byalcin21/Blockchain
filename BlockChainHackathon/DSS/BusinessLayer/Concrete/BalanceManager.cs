using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class BalanceManager : IBalanceService
    {
        IBalanceDal _balanceDal;

        public BalanceManager(IBalanceDal balanceDal)
        {
            _balanceDal = balanceDal;
        }

        public void BalanceAdd(Balance balance)
        {
            _balanceDal.Insert(balance);
        }

        public void BalanceDelete(Balance balance)
        {
            _balanceDal.Delete(balance);
        }

        public void BalanceUpdate(Balance balance)
        {
            _balanceDal.Update(balance);
        }

        public Balance GetByID(int id)
        {
            return _balanceDal.Get(x => x.BalanceID == id);
        }

        public List<Balance> GetList()
        {
            return _balanceDal.List();
        }
    }
}
