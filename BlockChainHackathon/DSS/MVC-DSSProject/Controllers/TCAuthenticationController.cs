using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace MVC_DSSProject.Controllers
{
    public class TCAuthenticationController : Controller
    {
        //Service Kullanımı
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [WebMethod]
        [HttpPost]
        public ActionResult Index(string Name, string Surname, long TCNo, int Year)
        {
            if(Name == "" || Surname == "")
            {
                Response.Write("Değerler Boş Geçilemez.");
            }
            else
            {
                using (TCAuthentication.KPSPublicSoapClient tc = new TCAuthentication.KPSPublicSoapClient())
                {
                    bool sonuc = tc.TCKimlikNoDogrula(TCNo, Name, Surname, Year);
                    if (sonuc == true)
                    {
                        Response.Write("<font color=\"green\"> Değerlendirmiş Olduğunuz Kullanıcı Türkiye Cumhuriyeti Vatandaşıdır.</font>");
                    }
                    else
                    {
                        Response.Write("<font color=\"red\"> Değerlendirmiş Olduğunuz Kullanıcı Türkiye Cumhuriyeti Vatandaşı Değildir. </font>");
                    }
                }
            }
            return View();
        }
    }
}