using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void UserAdd(User user)
        {
            _userDal.Insert(user);
        }

        public void UserDelete(User user)
        {
            _userDal.Delete(user);
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }

        public User GetByID(int id)
        {
            return _userDal.Get(x => x.UserID == id);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }
    }
}
