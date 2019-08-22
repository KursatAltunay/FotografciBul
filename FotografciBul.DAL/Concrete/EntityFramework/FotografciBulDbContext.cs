using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.Model;

namespace FotografciBul.DAL.Concrete.EntityFramework
{
    public class FotografciBulDbContext : DbContext
    {
        public FotografciBulDbContext() : base("Server=.;Database=FotografciBulDB;integrated security=true;")
        {
            Database.SetInitializer<FotografciBulDbContext>(new MyStrategy());
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Fotografci> Fotografcilar { get; set; }
        public DbSet<HizmetTipi> HizmetTipleri { get; set; }
        public DbSet<HizmetDetay> HizmetDetaylari { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<RandevuTalebi> RandevuTalepleri { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new HizmetDetayMapping());
           

            //modellerimin içindeki propertylerden tip olarak datetime kullanan varsa, sql tarafında karşılığını bulamaz diye tipini çevirme işlemi yapıyoruz.modelle ilgili değişiklik yaptığımız içinde bunu OnModelCreating metodunu override ederek yazıyoruz.
        }
    }
}
