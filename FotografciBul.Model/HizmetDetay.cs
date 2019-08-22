using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Model
{
    public class HizmetDetay
    {
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }

        //mapping gelen
        public int FotografciID { get; set; }
        public int HizmetID { get; set; }


        // mapping baglanti
        public Fotografci Fotografci { get; set; }
        public HizmetTipi HizmetTipi { get; set; }
    }
}
