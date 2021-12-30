using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DSSProject.Controllers
{
    [Authorize] // Kullanıcı Yetkisi Olmayan Hiç Kimse Görüntüleyemesin
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}