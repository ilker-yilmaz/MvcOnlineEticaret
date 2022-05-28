using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineEticaret.Models.Sınıflar;

namespace MvcOnlineEticaret.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context(); //yeni bir nesne üretiyoruz.
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
    }
}