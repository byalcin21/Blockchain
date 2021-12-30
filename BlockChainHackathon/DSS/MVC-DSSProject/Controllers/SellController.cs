using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_DSSProject.Controllers
{
    public class SellController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        SellManager sm = new SellManager(new EfSellDal());
        Context c = new Context();

        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }

        //Tüm İlanları Görüntüle -- User -- Sayfalama 1.sayfadan başlasın. Nuget Paketleri ekledik.-User
        public ActionResult UserAllSell(int p = 1)
        {
            var allsell = sm.GetList().ToPagedList(p, 10);
            return View(allsell);
        }

        //Tüm İlanları Görüntüle -- Admin -- Sayfalama 1.sayfadan başlasın. Nuget Paketleri ekledik.-Admin
        public ActionResult AdminAllSell(int p = 1)
        {
            var allsell = sm.GetList().ToPagedList(p, 10);
            return View(allsell);
        }

        //Yeni İlan Oluşturma - User
        [HttpGet]
        public ActionResult NewSell()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSell(Sell p)
        {
            SellValidator sellValidator = new SellValidator();
            ValidationResult results = sellValidator.Validate(p);

            if(results.IsValid)
            {
                string usermailinfo = (string)Session["UserMail"];
                var useridinfo = c.Users.Where(x => x.UserMail == usermailinfo).Select(y => y.UserID).FirstOrDefault();
                ViewBag.d = useridinfo;

                p.UserID = useridinfo;
                p.SellTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.State = true;
                sm.SellAdd(p);
                return RedirectToAction("UserAllSell");
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

        //Admin İlanı Düzenleyebilsin.
        public ActionResult EditSell(int id)
        {
            var sellValue = sm.GetByID(id);
            return View(sellValue);
        }
        [HttpPost]
        public ActionResult EditSell(Sell p)
        {
            sm.SellUpdate(p);
            return RedirectToAction("AdminAllSell");
        }

        //İlanı satıştan kaldır
        public ActionResult ActiveDeleteSell(int id)
        {
            var sellinfo = sm.GetByID(id);//parametre olarak gönderilen id ye göre getir
            if(sellinfo.State == false)
            {
                sellinfo.State = true;
            }
            else
            {
                sellinfo.State = false;
            }         
            sm.SellUpdate(sellinfo);
            return RedirectToAction("AdminAllSell");
        }
    }
}