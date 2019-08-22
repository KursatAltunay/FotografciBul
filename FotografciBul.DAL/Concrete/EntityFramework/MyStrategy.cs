using FotografciBul.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.DAL.Concrete.EntityFramework
{
    class MyStrategy : DropCreateDatabaseIfModelChanges<FotografciBulDbContext>
    {
        protected override void Seed(FotografciBulDbContext context)
        {
            var hizmetTipi = new List<HizmetTipi>
            {
                new HizmetTipi { Adi = "Düğün" },
                new HizmetTipi { Adi = "Doğum" },
                new HizmetTipi { Adi = "Bebek" },
                new HizmetTipi { Adi = "Mezuniyet" },
                new HizmetTipi { Adi = "Doğum Günü" },
                new HizmetTipi { Adi = "Moda" },
                new HizmetTipi { Adi = "Ürün" }
            };

            context.HizmetTipleri.AddRange(hizmetTipi);


            var kullanici = new List<Kullanici>
            {
                new Kullanici{ Email="user@mail.com", Sifre="123456", OnaylanmisMi=true, SilindiMi=false, Adi="User", Soyadi="Foto", Telefon="05555555555", OlusturulmaTarihi=DateTime.Now, DogumTarihi=DateTime.Now },
                new Kullanici{ Email="gozluklucocuk@mail.com", Sifre="123456", OnaylanmisMi=true, SilindiMi=false, Adi="Gozluklu", Soyadi="Cocuk", Telefon="02124440333", OlusturulmaTarihi=DateTime.Now, DogumTarihi=DateTime.Now },
                new Kullanici{ Email="cicek.abbas@mail.com", Sifre="123456", OnaylanmisMi=true, SilindiMi=false, Adi="Cicek", Soyadi="Abbas", Telefon="05555555555", OlusturulmaTarihi=DateTime.Now, DogumTarihi=DateTime.Now },
                new Kullanici{ Email="kullanici@mail.com", Sifre="123456", OnaylanmisMi=true, SilindiMi=false, Adi="Cansu", Soyadi="Altunbas", Telefon="01111111", OlusturulmaTarihi=DateTime.Now, DogumTarihi=DateTime.Now }
            };

            context.Kullanicilar.AddRange(kullanici);


            var fotografci = new List<Fotografci>
            {
                //new Fotografci{ Email="admin@mail.com", Sifre="123456", ID=1, SilindiMi=false, Adi="User", Telefon="05555555555", OlusturulmaTarihi=DateTime.Now}


                new Fotografci { Adi="Ece Fotografcilik", Adres="ııjjkhkjhkj", Email="admin@mail.com", Sifre="123456",Sehir="Istanbul", Telefon="05555555555",Fotograf="foto-2.jpg", Aciklama="Kişisel ilgiyle başlayan sektör hayatıma birçok alanda hizmet vererek devam etmekteyim." },
                new Fotografci { Adi="Burak Bulut Fotografcilik", Adres="aueruıer", Email="aueruıer@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-3.jpg", Aciklama="20 yılı aşkın hizmet geçmişimizle en güzel anlarınızı ölümsüzleştiriyoruz." },
                new Fotografci { Adi="Tarık Akan", Adres="uytrtrer", Email="uytrtrer@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-1.jpg", Aciklama="Vesikalıktan düğün çekimlerine kadar hemen her alanda hizmetinizdeyiz." },
                new Fotografci { Adi="Filiz Akın", Adres="Kadıköy", Email="akinfiliz@gmail.com", Sehir="Istabul", Telefon="05555555555", Fotograf="foto-1.jpg", Aciklama="Ivır Zıvır" },
                new Fotografci { Adi="Ediz Hun", Adres="mamak", Email="ediz.hun@gmail.com", Sehir="Ankara", Telefon="05555222225", Fotograf="foto-1.jpg", Aciklama="Senin annen bir melekti yavrum" },
                new Fotografci { Adi="Cüneyt Arkın", Adres="Balgat", Email="cuneyt.arkin@gmail.com", Sehir="Ankara", Telefon="05555554444", Fotograf="foto-1.jpg", Aciklama="Hain kostok" },
                new Fotografci { Adi="Kemal Sunal", Adres="Nilüfer", Email="kemal.sunal@gmail.com", Sehir="Bursa", Telefon="053333333", Fotograf="foto-1.jpg", Aciklama="Essoglessek" },
                new Fotografci { Adi="Türkan Şoray", Adres="çekirge", Email="turkan.soray@gmail.com", Sehir="Bursa", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="Sevgi neydi? Sevgi emekti." },

                new Fotografci { Adi="İlyas Salman", Adres="mamak", Email="ilyas.salman@gmail.com", Sehir="Ankara", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="civ civ" },

                new Fotografci { Adi="Mehmet Ali Erbil", Adres="Polatlı", Email="mali.erbil@gmail.com", Sehir="Ankara", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="Dobrowski" },

                new Fotografci { Adi="Ferdi Tayfur", Adres="çekirge", Email="ferdi.tayfur@gmail.com", Sehir="Bursa", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="Emmoglu" }
                ,
                new Fotografci { Adi="Cimilli İbo", Adres="çekirge", Email="cimilli.ibo@gmail.com", Sehir="Bursa", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="uy uy" },

                new Fotografci { Adi="İsmail Türüt", Adres="Maslak", Email="ismail.turut@gmail.com", Sehir="Istanbul", Telefon="05554444555", Fotograf="foto-4.jpg", Aciklama="pilan yapmayın" },

                new Fotografci { Adi="Emre Belözoğlu", Adres="Kadıköy", Email="emre.belozoglu@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="fenerbaheç" },

                new Fotografci { Adi="Sergen Yalçın", Adres="Beşiktaş", Email="Sergen.Yalçın@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="beşiktaş" }

            };
            //new List<Fotografci>
            //{
            //    new Fotografci { Adi="Ece Fotografcilik", Adres="ııjjkhkjhkj", Email="admin@mail.com", Sifre="123456",Sehir="Istanbul", Telefon="05555555555",Fotograf="foto-2.jpg", Aciklama="Kişisel ilgiyle başlayan sektör hayatıma birçok alanda hizmet vererek devam etmekteyim." },
            //    new Fotografci { Adi="Burak Bulut Fotografcilik", Adres="aueruıer", Email="aueruıer@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-3.jpg", Aciklama="20 yılı aşkın hizmet geçmişimizle en güzel anlarınızı ölümsüzleştiriyoruz." },
            //    new Fotografci { Adi="Tarık Akan", Adres="uytrtrer", Email="uytrtrer@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-1.jpg", Aciklama="Vesikalıktan düğün çekimlerine kadar hemen her alanda hizmetinizdeyiz." },
            //    new Fotografci { Adi="Alihan Kutlu", Adres="wqwwewerwer", Email="wqwwewerwer@gmail.com", Sehir="Istanbul", Telefon="05555555555", Fotograf="foto-4.jpg", Aciklama="Mezuniyet, kutlama gibi birçok alanda hizmetinizdeyiz." }
            //}.ForEach(a => context.Fotografcilar.Add(a));

            context.Fotografcilar.AddRange(fotografci);


            var hizmetDetay = new List<HizmetDetay>
            {
                new HizmetDetay{ FotografciID=1, HizmetID=1, Fiyat=20, Aciklama="" },
                new HizmetDetay{ FotografciID=1, HizmetID=2, Fiyat=30, Aciklama="" },
                new HizmetDetay{ FotografciID=1, HizmetID=3, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=1, HizmetID=4, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=1, HizmetID=5, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=1, HizmetID=6, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=1, HizmetID=7, Fiyat=40, Aciklama="" },

                new HizmetDetay{ FotografciID=2, HizmetID=1, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=2, HizmetID=2, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=2, HizmetID=3, Fiyat=50, Aciklama="" },
                new HizmetDetay{ FotografciID=2, HizmetID=4, Fiyat=30, Aciklama="" },
                new HizmetDetay{ FotografciID=2, HizmetID=5, Fiyat=40, Aciklama="" },

                new HizmetDetay{ FotografciID=3, HizmetID=1, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=3, HizmetID=2, Fiyat=60, Aciklama="" },

                new HizmetDetay{ FotografciID=4, HizmetID=1, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=4, HizmetID=2, Fiyat=50, Aciklama="" },
                new HizmetDetay{ FotografciID=4, HizmetID=3, Fiyat=70, Aciklama="" },
                new HizmetDetay{ FotografciID=4, HizmetID=5, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=4, HizmetID=6, Fiyat=50, Aciklama="" },
                new HizmetDetay{ FotografciID=4, HizmetID=7, Fiyat=70, Aciklama="" },


                new HizmetDetay{ FotografciID=7, HizmetID=1, Fiyat=20, Aciklama="" },
                new HizmetDetay{ FotografciID=7, HizmetID=2, Fiyat=30, Aciklama="" },
                new HizmetDetay{ FotografciID=7, HizmetID=3, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=7, HizmetID=4, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=7, HizmetID=5, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=7, HizmetID=6, Fiyat=40, Aciklama="" },
                new HizmetDetay{ FotografciID=7, HizmetID=7, Fiyat=40, Aciklama="" },
            };

            context.HizmetDetaylari.AddRange(hizmetDetay);



            DateTime date = new DateTime(2019, 08, 08);
            DateTime date1 = new DateTime(2019, 09, 09);


            var randevuTalebi = new List<RandevuTalebi>
            {
                new RandevuTalebi{ FotografciID=1, KullaniciID=1, HizmetID=1, OlusturulmaTarihi=DateTime.Now, RandevuTarihi=date},
                new RandevuTalebi{ FotografciID=1, KullaniciID=1, HizmetID=3, OlusturulmaTarihi=DateTime.Now, RandevuTarihi=date},
                new RandevuTalebi{ FotografciID=1, KullaniciID=1, HizmetID=4, OlusturulmaTarihi=DateTime.Now, RandevuTarihi=date1},
                new RandevuTalebi{ FotografciID=2, KullaniciID=1, HizmetID=1, OlusturulmaTarihi=DateTime.Now, RandevuTarihi=date1}
            };

            context.RandevuTalepleri.AddRange(randevuTalebi);


            var fotografciResim = new List<Resim>
            {
                new Resim{ FotografciID=1, ResimAdi="hero_1.jpg" },
                new Resim{ FotografciID=1, ResimAdi="hero_2.jpg"},
                new Resim{ FotografciID=1, ResimAdi="hero_3.jpg"},
                new Resim{ FotografciID=1, ResimAdi="hero_4.jpg"},
                new Resim{ FotografciID=1, ResimAdi="hero_5.jpg"},
                new Resim{ FotografciID=2, ResimAdi="img_1.jpg"},
                new Resim{ FotografciID=2, ResimAdi="img_2.jpg"}
            };

            context.Resimler.AddRange(fotografciResim);


            context.SaveChanges();

        }
    }
}