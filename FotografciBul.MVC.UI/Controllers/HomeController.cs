using FotografciBul.BLL.Abstract;
using FotografciBul.DAL.Concrete.EntityFramework;
using FotografciBul.Model;
using FotografciBul.MVC.UI.CustomFilter;
using FotografciBul.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FotografciBul.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        IHizmetTipiService _hizmetTipi;
        IFotografciService _fotografcilar;
        IKullaniciService _kullaniciService;

        public HomeController(IHizmetTipiService hizmetTipiService, IFotografciService fotografciService, IKullaniciService kullaniciService)
        {
            _hizmetTipi = hizmetTipiService;
            _fotografcilar = fotografciService;
            _kullaniciService = kullaniciService;
        }

        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                Kullanici girisYapanKullanici = _kullaniciService.Get(id.Value);
                Session["Kullanici"] = girisYapanKullanici;
                ViewBag.Kullanici = girisYapanKullanici.Adi;

            }

            var hizmetTipi = _hizmetTipi.GetAll();
            return View(hizmetTipi);
        }

        public ActionResult Fotografcilar()
        {
            return PartialView(_fotografcilar.GetAll());
        }

        public ActionResult Fotograflar()
        {
            return PartialView();
        }

        public ActionResult Paketler()
        {
            return PartialView();
        }

        public int fotoID;
        //[CustomFilter]
        public ActionResult Bul(string hizmetTipi, string fotoSehir, DateTime? randevuTarih)
        {
            RandevuItemDTO dto = new RandevuItemDTO();


            int hizmetID = _hizmetTipi.GetAll().Where(a => a.Adi == hizmetTipi).FirstOrDefault().ID;

            dto.HizmetID = hizmetID;
            dto.RandevuTarihi = DateTime.Now;

            ViewBag.RandevuDetay = dto;

            FotografciBulDbContext _dbContext = new FotografciBulDbContext();
            List<Fotografci> sehirdekiFotografcilar = _fotografcilar.GetAll().Where(a => a.Sehir == fotoSehir).ToList();
            List<HizmetDetay> hizmetDetayListesi = _dbContext.HizmetDetaylari.ToList();
            List<Fotografci> filtrelenmisFotografcilar = new List<Fotografci>();


            foreach (var aparat in hizmetDetayListesi)
            {
                if (aparat.HizmetID == hizmetID)
                {
                    fotoID = aparat.FotografciID;
                    foreach (var item in sehirdekiFotografcilar)
                    {
                        if (fotoID == item.ID)
                        {
                            filtrelenmisFotografcilar.Add(item);
                        }
                    }
                }

            }
            return View(filtrelenmisFotografcilar);



        }


        public ActionResult MailResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MailResult(Contact model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " + model.Name);
                body.AppendLine("E-Mail Adresi: " + model.Email);
                body.AppendLine("Konu: " + model.Subject);
                body.AppendLine("Mesaj: " + model.Message);
                Mail.MailSender(body.ToString(), model);
                ViewBag.Success = true;
            }
            return View();
        }
    }
}
