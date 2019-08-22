using FotografciBul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Model
{
    public class RandevuTalebi : BaseEntity
    {
        public RandevuTalebi()
        {
            OnayDurumu = false;
        }

        public DateTime RandevuTarihi { get; set; }
        public bool OnayDurumu { get; set; }

        //Mapping gelenler
        public int KullaniciID { get; set; }
        public int FotografciID { get; set; }
        public int HizmetID { get; set; }


        //mapping baglantılar

        public virtual Kullanici Kullanici { get; set; }
        public virtual Fotografci Fotografci { get; set; }
        public virtual HizmetTipi HizmetTipi { get; set; }
    }
}
