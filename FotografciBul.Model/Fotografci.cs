using FotografciBul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Model
{
    public class Fotografci : BaseEntity
    {
        public Fotografci() //fotoğrafçı ilk oluştuğunda gelecek default özellikler
        {
            Aciklama = "Yeni Üye";
            Fotograf = "default.jpg";
        }

        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Adi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; } //Duruma göre Enum olabilir
        public string Fotograf { get; set; }
        public string Aciklama { get; set; }

        //mapping gidenler
        public List<RandevuTalebi> RandevuTalebi { get; set; }
        public List<Resim> Resimler { get; set; }
        public List<HizmetDetay> HizmetDetay { get; set; }
    }
}
