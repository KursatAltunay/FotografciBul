using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.Core.DAL.EntityFramework;
using FotografciBul.DAL.Abstract;
using FotografciBul.Model;

namespace FotografciBul.DAL.Concrete.EntityFramework
{
    public class KullaniciRepository: EFRepositoryBase<Kullanici,FotografciBulDbContext>,IKullaniciDAL
    {
    }
}
