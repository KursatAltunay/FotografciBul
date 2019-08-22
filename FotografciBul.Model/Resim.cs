using FotografciBul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Model
{
    public class Resim : BaseEntity
    {
        public string ResimAdi { get; set; }

        //mapping gelen
        public int FotografciID { get; set; }

        //mapping baglanti
        public virtual Fotografci Fotografci { get; set; }

    }
}
