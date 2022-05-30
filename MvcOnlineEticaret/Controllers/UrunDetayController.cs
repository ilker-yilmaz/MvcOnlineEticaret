using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineEticaret.Models.Sınıflar;

namespace MvcOnlineEticaret.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            return View(degerler);
        }
    }
}