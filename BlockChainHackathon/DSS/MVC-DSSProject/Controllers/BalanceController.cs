using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace MVC_DSSProject.Controllers
{
    public class BalanceController : Controller
    {
        BalanceManager um = new BalanceManager(new EfBalanceDal());
        AccountManager accountManager = new AccountManager(new EfAccountDal());
        Context c = new Context();

        //Kullanıcı Para Eklemek İçin Onay Tablosuna İstek Bırakıyor.
        [HttpGet]
        public ActionResult AddBalance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBalance(Balance p)
        {
            BalanceValidator sellValidator = new BalanceValidator();
            ValidationResult results = sellValidator.Validate(p);

            if (results.IsValid)
            {
                string usermailinfo = (string)Session["UserMail"];
                var useridinfo = c.Users.Where(x => x.UserMail == usermailinfo).Select(y => y.UserID).FirstOrDefault();
                ViewBag.d = useridinfo;

                p.UserID = useridinfo;
                p.State = true;
                um.BalanceAdd(p);
                //İşlem tamamlandığında UserController'ın UserProfile View'ına git.
                return RedirectToAction("UserProfile", "User");
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

        //Tüm ödeme isteklerini görüntüleme
        public ActionResult AllBalance(int p = 1)
        {
            var allsell = um.GetList().ToPagedList(p, 10);
            return View(allsell);
        }


        //Ödeme Kabul İşlemleri
        public ActionResult AcceptBalance(int id)
        {
            var p = um.GetByID(id);
            p.State = false;
            um.BalanceUpdate(p); //Ödeme işleme alındı. State'ini false yap.

            //Kullanıcının eklenmesini beklediği tutar ve eklenecek kişiyi p parametresinden alıyoruz.
            var balancevalue = p.BalanceValue;

            //Aldığımız user ıd parametresi ile kullanıcıyı bulup, hesap numarasını tespit ediyoruz.
            var userAccountinfo = c.Users.Where(x => x.UserID == p.UserID).Select(y => y.AccountID).FirstOrDefault();
            var userNowBalanceInfo = c.Accounts.Where(x => x.AccountID == userAccountinfo).Select(y => y.Balance).FirstOrDefault();

            Account a = new Account();
            a.AccountID = userAccountinfo;
            var newBalance = ((float)userNowBalanceInfo) + ((float)balancevalue);
            a.Balance = ((float)newBalance); //Hesabındaki şu anki miktar + yeni tutar
            accountManager.AccountUpdate(a);

            return RedirectToAction("AllBalance");
        }
    }
}