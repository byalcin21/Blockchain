using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AuthorityManager : IAuthorityService
    {
        IAuthorityDal _authorityDal;

        public AuthorityManager(IAuthorityDal authorityDal)
        {
            _authorityDal = authorityDal;
        }

        public void AuthorityAdd(Authority authority)
        {
            _authorityDal.Insert(authority);
        }

        public void AuthorityDelete(Authority authority)
        {
            _authorityDal.Delete(authority);
        }

        public void AuthorityUpdate(Authority authority)
        {
            _authorityDal.Update(authority);
        }

        public Authority GetByID(int id)
        {
            return _authorityDal.Get(x => x.AuthorityID == id);
        }

        public List<Authority> GetList()
        {
            return _authorityDal.List();
        }
    }
}
