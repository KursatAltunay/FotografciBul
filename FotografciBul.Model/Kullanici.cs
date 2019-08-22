using FotografciBul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Model
{
    public class Kullanici : BaseEntity
    {
        public Kullanici()
        {
            OnaylanmisMi = false;
        }

        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public bool OnaylanmisMi { get; set; }

        // mapping giden
        public List<RandevuTalebi> RandevuTalebi { get; set; }
    }
}
