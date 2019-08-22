using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.Model;

namespace FotografciBul.DAL.Concrete.EntityFramework
{
    public class HizmetDetayMapping:EntityTypeConfiguration<HizmetDetay>
    {
        public HizmetDetayMapping()
        {
            HasKey(a => new { a.FotografciID, a.HizmetID });
        }
    }
}
