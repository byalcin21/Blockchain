using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_DSSProject.Controllers
{
    [AllowAnonymous] // Dışarıdan Kullanıcı Yetkisi Olmadan Erişilebilir Olmasını Sağlıyoruz.
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        AuthorityManager authorityManager = new AuthorityManager(new EfAuthorityDal());

        //Giriş Yetkinlendirme
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User p)
        {
            var userinfo = um.GetList().FirstOrDefault(x => x.UserMail == p.UserMail && x.UserPassword == p.UserPassword);

            if (userinfo != null && userinfo.State!=false)
            {
                var authorityinfo = authorityManager.GetByID(userinfo.AuthorityID);
                FormsAuthentication.SetAuthCookie(userinfo.UserMail, false);
                Session["UserMail"] = userinfo.UserMail;

                if (authorityinfo.AuthorityLevel == true)                  
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Index", "User");                         
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}