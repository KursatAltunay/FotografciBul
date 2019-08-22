using FotografciBul.BLL.Abstract;
using FotografciBul.Model;
using FotografciBul.MVC.UI.CustomFilter;
using FotografciBul.MVC.UI.Models;
using FotografciBul.MVC.UI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FotografciBul.MVC.UI.Controllers
{
    public class UserController : Controller
    {
        IKullaniciService _kullaniciService;
        IFotografciService _fotografcilar;
        IHizmetTipiService _hizmetTipi;
        IRandevuTalebiService _randevuTalebiService;
        Kullanici aktifkullanici = new Kullanici();
        int kullaniciID;

        public UserController(IKullaniciService kullaniciService, IHizmetTipiService hizmetTipi, IFotografciService fotografciService, IRandevuTalebiService randevuTalebiService)
        {
            _randevuTalebiService = randevuTalebiService;
            _kullaniciService = kullaniciService;
            _hizmetTipi = hizmetTipi;
            _fotografcilar = fotografciService;
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(Kullanici kullanici)
        {
            Kullanici gelenKullanici = _kullaniciService.GetUserByLogin(kullanici.Email, kullanici.Sifre);
            if (gelenKullanici != null)
            {
                Session["kullanici"] = gelenKullanici;
                kullaniciID = gelenKullanici.ID;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "HATA! Kullanıcı adı veya şifreniz yanlış!";
            //return View(gelenKullanici);
            return RedirectToAction("UserLogin");
        }

        public ActionResult _KullaniciBilgileri(int id)
        {
            return PartialView(_kullaniciService.Get(id)); //kullanıcı bilgileri
        }

        [CustomFilter]
        public ActionResult KullaniciAnasayfa(string fotografciID, RandevuItemDTO dto)
        {
            Kullanici kullanici = Session["kullanici"] as Kullanici;
            RandevuTalebi randevu = new RandevuTalebi();
            //id = kullanici.ID;
            //ViewBag.ID = id;
            //int hizmetID = _hizmetTipi.GetAll().Where(a => a.Adi == hizmetTipi).FirstOrDefault().ID;
            //ViewBag.hizmet = hizmetID;
            //int fotoID = _fotografcilar.GetAll().Where(a => a.Adi == fotografciID).FirstOrDefault().ID;
            //ViewBag.foto = fotoID;
            ViewBag.kullaniciIsmi = kullanici.Adi + " " + kullanici.Soyadi;
            try
            {
                _randevuTalebiService.Insert(randevu);
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Veritabanına ekleme başarısız oldu!";
                return View();
            }
        }

        //public Action

        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(Kullanici kullanici)
        {
            try
            {
                _kullaniciService.Insert(kullanici);
                bool sonuc = MailHelper.SendConfirmationMail(kullanici.Adi, kullanici.Sifre, kullanici.Email, kullanici.ID);
                if (!sonuc)
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Veritabanına ekleme hatası!";
                return View();
            }
            return RedirectToAction("UserLogin", "User");
        }

        public ActionResult _Fotografcilar()
        {
            return PartialView(_fotografcilar.GetAll());
        }

        public ActionResult _Hizmetler(int id)
        {
            return PartialView(_hizmetTipi.GetAll());
        }
    }
}