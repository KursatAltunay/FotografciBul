using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.DAL.Abstract;
using FotografciBul.DAL.Concrete.EntityFramework;
using Ninject.Modules;

namespace FotografciBul.BLL.Ninject
{
    public class CustomDALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFotografciDAL>().To<FotografciRepository>();
            Bind<IKullaniciDAL>().To<KullaniciRepository>();
            Bind<IHizmetTipiDAL>().To<HizmetTipiRepository>();
            Bind<IRandevuTalebiDAL>().To<RandevuTalebiRepository>();
            Bind<IResimDAL>().To<ResimRepository>();
        }
    }
}
