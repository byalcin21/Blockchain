using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfAccountDal : GenericRepository<Account>, IAccountDal
    {
    }
}
