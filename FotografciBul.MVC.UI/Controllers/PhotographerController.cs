using FotografciBul.BLL.Abstract;
using FotografciBul.DAL.Concrete.EntityFramework;
using FotografciBul.Model;
using FotografciBul.MVC.UI.CustomFilter;
using FotografciBul.MVC.UI.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FotografciBul.MVC.UI.Controllers
{
    public class PhotographerController : Controller
    {
        IRandevuTalebiService _randevuTalebi;
        IFotografciService _fotografciService;
        IHizmetTipiService _hizmetTipiService;
        Fotografci girisYapanKullanici = new Fotografci();  //sisteme giriş yapan fotoğrafçı bilgisi burada tutuluyor.
        FotografciBulDbContext db;
        int sistemdekiFotografciID;
        public PhotographerController(IRandevuTalebiService randevuTalebi, IFotografciService fotografciService)
        {
            _randevuTalebi = randevuTalebi;
            _fotografciService = fotografciService;
            db = new FotografciBulDbContext();
        }

        [HttpGet]
        public ActionResult FotografciGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FotografciGiris(Fotografci fotografci)
        {
            girisYapanKullanici = _fotografciService.GetPhotographerByLogin(fotografci.Email, fotografci.Sifre);

            if (girisYapanKullanici != null) //böyle bir kullanıcı var mı?
            {
                Session["fkullanici"] = girisYapanKullanici;
                sistemdekiFotografciID = girisYapanKullanici.ID;
                return RedirectToAction("FotografciAnasayfa", new { id = sistemdekiFotografciID }); //var ise fotoğrafçı id ile anasayfaya git //
            }
            //yoksa login sayfasına hata mesajı ile geri dön

            ViewBag.Mesaj = "Hata! Yanlış kullanıcı adı ya da şifre";
            return RedirectToAction("FotografciGiris");

        }

        public ActionResult FotografciKaydet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FotografciKaydet(Fotografci fotografci)
        {
            _fotografciService.Insert(fotografci);
            ViewBag.Mesaj = "Kayıt başarılı";
            return RedirectToAction("FotografciGiris");
        }
        
        public ActionResult FotografciAnasayfa()
        {
            Fotografci fotografci = Session["fkullanici"] as Fotografci;
            int id = fotografci.ID;
            ICollection<RandevuTalebi> randevular = _randevuTalebi.OlusturulmaTarihineGoreTumRandevular(id);
            ViewBag.KullaniciID = id;
            return View(randevular);
        }

        public ActionResult RezervasyonGuncelle(int id, string durum)
        {
            RandevuTalebi gecerliRandevu = _randevuTalebi.Get(id);
            if (durum == "onayla")
            {
                gecerliRandevu.OnayDurumu = true;
            }
            else
            {
                gecerliRandevu.OnayDurumu = false;
            }

            _randevuTalebi.Update(gecerliRandevu);
            return RedirectToAction("FotografciAnasayfa");
        }

        public ActionResult _FotografciBilgileri(int id)
        {
            return PartialView(_fotografciService.Get(id)); //ilgili fotoğrafçı gönderiliyor
        }

        public ActionResult _FotografciFotograflari(int fotografciID)
        {
            ICollection<string> resimUzantilari = db.Resimler.Where(a => a.FotografciID == fotografciID).Select(a => a.ResimAdi).ToList();
            return PartialView(resimUzantilari);
        }
        
        public ActionResult BilgileriDuzenle()
        {
            Fotografci fotografci = Session["fkullanici"] as Fotografci;

            return View(_fotografciService.Get(fotografci.ID));
        }

        [HttpPost]
        public ActionResult BilgileriDuzenle(Fotografci fotografci, string sehir)
        {
            Fotografci girisYapanFotografci = Session["fkullanici"] as Fotografci;

            girisYapanFotografci.Adres = fotografci.Adres;
            girisYapanFotografci.Sehir = fotografci.Sehir;
            girisYapanFotografci.Aciklama = fotografci.Aciklama;
            _fotografciService.Update(girisYapanFotografci);
            return RedirectToAction("BilgileriDuzenle");
        }

        [HttpPost]
        public ActionResult FotoKaydet(HttpPostedFileBase uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Assets/images"));
                uploadFile.SaveAs(filePath);
            }
            return RedirectToAction("BilgileriDuzenle");
        }

        //public ActionResult _FotografciHizmetleriniDuzenle()
        //{
        //    Fotografci kullanici = Session["fkullanici"] as Fotografci;
        //    return PartialView(db.HizmetDetaylari.Where(a => a.FotografciID==kullanici.ID));
        //}


    }
}
