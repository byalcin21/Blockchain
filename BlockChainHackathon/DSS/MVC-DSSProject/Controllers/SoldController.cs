using BusinessLayer.Concrete;
using DataAccessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC_DSSProject.Controllers
{
    public class SoldController : Controller
    {
        SoldManager soldm = new SoldManager(new EfSoldDal());
        SellManager sellm = new SellManager(new EfSellDal());
        AccountManager accountm = new AccountManager(new EfAccountDal());
        UserManager userm = new UserManager(new EfUserDal());
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        //Tamamlanan İşlemleri Görüntüle
        public ActionResult AdminAllSold(int p = 1)
        {
            var allsold = soldm.GetList().ToPagedList(p, 10);
            return View(allsold);
        }

        //Kullanıcının Satın Aldıklarını Getir -- Kullanıcıya Göre Kısıtlı
        public ActionResult MySolds(string p)
        {
            p = (string)Session["UserMail"];
            var writeridinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            var values = soldm.GetListMySold(writeridinfo);
            return View(values);
        }

        //Satın Alma İşlemi -  Hash ve Para İşlemleri
        public ActionResult BuyAndHash(int id)
        {
            //Satın alan kişinin bilgileri
            string usermailinfo = (string)Session["UserMail"];
            var useridinfo = c.Users.Where(x => x.UserMail == usermailinfo).Select(y => y.UserID).FirstOrDefault(); //Kullanıcının ID bilgisi. Bakiye düşmek için gerekli.
            var userinfo = userm.GetByID(useridinfo); //Kullanıcının bilgilerini getiriyoruz. Hesabına ulaşmak için gerekli.
            //Hesap ID'sine göre hesap bilgilerini getiriyoruz.
            var accountinfo = accountm.GetByID(userinfo.AccountID);

            //Satılan Ürüne Dair Bilgileri Çekiyoruz.
            var sellinfo = sellm.GetByID(id);

            //Satan kullanıcının bilgileri
            var sellerinfo = userm.GetByID(sellinfo.UserID);
            //Satan kullanıcının hesap bilgileri
            var selleraccountinfo = accountm.GetByID(sellerinfo.AccountID);


            if (accountinfo.Balance < sellinfo.SellValue)
            {
                return View("NotSell");
            }
            else
            {
                //Satım işlemi başladı. Ürün gösterimden kaldırılıyor.
                sellinfo.State = false;
                sellm.SellUpdate(sellinfo);

                //Para işlemleri
                //Kullanıcıdan bakiye düşme
                var lastmoney = (accountinfo.Balance) - (sellinfo.SellValue);
                accountinfo.Balance = lastmoney;//Kullanıcının para değerini azalttık.
                accountm.AccountUpdate(accountinfo);

                //Satıcı parasını alıyor.
                var sellmoney = (sellinfo.SellValue) + (selleraccountinfo.Balance);
                selleraccountinfo.Balance = sellmoney;
                accountm.AccountUpdate(selleraccountinfo);

                //Toblodaki son hash'i alıyouz.
                var lastsold = c.Solds.OrderByDescending(u => u.LastHash).FirstOrDefault();

                //Satıldı tablosuna hash ve kayıt işlemleri.
                //Satıma dair tüm bilgiler.
                var productinfo = sellinfo.ToString() + lastsold.LastHash.ToString();


                //Satın alma kayıt /sold tablosuna kayıt
                var lasthash = Crypto.SHA256(productinfo);

                Sold p = new Sold();
                p.SellID = sellinfo.SellID;
                p.UserID = useridinfo;
                p.PrevHash = lastsold.LastHash;
                p.LastHash = lasthash;
                soldm.SoldAdd(p);
            }
            return RedirectToAction("UserAllSell", "Sell");
        }

        public ActionResult NotSell()
        {
            return View();
        }
    }
}