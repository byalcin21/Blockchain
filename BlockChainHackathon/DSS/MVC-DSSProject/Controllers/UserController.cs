using BusinessLayer.Concrete;
using DataAccessLayer.Conrete;
using System.Linq;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MVC_DSSProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserManager us = new UserManager(new EfUserDal());
        AccountManager bm = new AccountManager(new EfAccountDal());
        Context c = new Context();

        //Index Bu Controller İçin Anasayfa
        public ActionResult Index()
        {
            return View();
        }
        
        //Kullanıcı Bilgisini Dönüyoruz.
        public ActionResult UserProfile()
        {
            string p = (string)Session["UserMail"];
            var id = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();        //Giriş yapan kullanıcıyı seçiyoruz.
            var uservalue = us.GetByID(id);  //Seçiş olduğumuz kullanıcının bilgilerini çekiyoruz.
            var deneme = bm.GetByID(uservalue.AccountID);
            uservalue.Account.Balance = deneme.Balance;
            return View(uservalue);
        }

        //Admin Tarafı Kullanıcılar
        public ActionResult AllUser()
        {
            var Users = us.GetList();
            return View(Users);
        }

        //Kullanıcının Erişimini Engelle
        public ActionResult ActiveDeleteUser(int id)
        {
            var userinfo = us.GetByID(id);//parametre olarak gönderilen id ye göre getir
            if(userinfo.State == false)
            {
                userinfo.State = true;
            }
            else
            {
                userinfo.State = false;
            }    
            us.UserUpdate(userinfo);
            return RedirectToAction("AllUser");
        }

        //Kullanıcı Bilgilerini Güncelleme  - State/id/Account Id Hariç
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var uservalue = us.GetByID(id);
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult EditUser(User p)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(p);

            if (results.IsValid)
            {
                us.UserUpdate(p);
                return RedirectToAction("AllUser");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}