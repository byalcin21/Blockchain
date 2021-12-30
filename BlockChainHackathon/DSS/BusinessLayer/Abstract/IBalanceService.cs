using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IBalanceService
    {
        List<Balance> GetList();
        void BalanceAdd(Balance balance);
        Balance GetByID(int id);
        void BalanceDelete(Balance balance);
        void BalanceUpdate(Balance balance);
    }
}
