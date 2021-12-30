using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ISellService
    {
        List<Sell> GetList();
        void SellAdd(Sell sell);
        Sell GetByID(int id);
        void SellDelete(Sell sell);
        void SellUpdate(Sell sell);
    }
}
