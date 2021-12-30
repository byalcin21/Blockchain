using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ISoldService
    {
        List<Sold> GetList();
        void SoldAdd(Sold sold);
        Sold GetByID(int id);
        void SoldDelete(Sold sold);
        void SoldUpdate(Sold sold);
    }
}
