using FotografciBul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Model
{
    public class HizmetTipi : BaseEntity
    {
        public string Adi { get; set; } //Enum olabilir

        // mapping giden
        public virtual List<HizmetDetay> HizmetDetay { get; set; }
    }
}
