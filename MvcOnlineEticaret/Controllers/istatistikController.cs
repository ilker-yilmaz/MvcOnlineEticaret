using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineEticaret.Models.Sınıflar;

namespace MvcOnlineEticaret.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString(); //toplam cari
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString(); //toplam ürün
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString(); //toplam personel
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString(); //kategoriler
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString(); //toplam stok sayısı
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString(); //marka sayısı
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString(); //kritik seviye
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault(); //max fiyatlı ürün
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault(); //min fiyatlı ürün
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString(); //buzdolabı sayısı
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString(); //laptop sayısı
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault(); //max marka: ismi en çok tekrar eden marka
            ViewBag.d12 = deger12;
            var deger13 = c.Uruns.Where(u => u.Urunid == (c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault(); //en çok satan
            ViewBag.d13 = deger13;
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString(); //kasadaki tutar
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString(); //bugünkü satışlar
            ViewBag.d15 = deger15;
            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString(); //bugünkü kasa
            ViewBag.d16 = deger16;

            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            marka = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }


    }
}