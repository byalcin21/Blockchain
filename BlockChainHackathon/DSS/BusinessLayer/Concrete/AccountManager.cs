using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public void AccountAdd(Account account)
        {
            _accountDal.Insert(account);
        }

        public void AccountDelete(Account account)
        {
            _accountDal.Delete(account);
        }

        public void AccountUpdate(Account account)
        {
            _accountDal.Update(account);
        }

        public Account GetByID(int id)
        {
            return _accountDal.Get(x => x.AccountID == id);
        }

        public List<Account> GetList()
        {
            return _accountDal.List();
        }
    }
}
