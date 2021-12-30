using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ILoginService
    {
        User GetUser(string userName, string password);
    }
}
