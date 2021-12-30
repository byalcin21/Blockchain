using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAuthorityService
    {
        List<Authority> GetList();
        void AuthorityAdd(Authority authority);
        Authority GetByID(int id);
        void AuthorityDelete(Authority authority);
        void AuthorityUpdate(Authority authority);
    }
}
