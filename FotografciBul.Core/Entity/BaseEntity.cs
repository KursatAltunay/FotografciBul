using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.Core.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            OlusturulmaTarihi = DateTime.Now;
            SilindiMi = false;
        }

        public int ID { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public bool SilindiMi { get; set; }
    }

}
