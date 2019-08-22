using FotografciBul.Core.DAL.EntityFramework;
using FotografciBul.DAL.Abstract;
using FotografciBul.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.DAL.Concrete.EntityFramework
{
    public class ResimRepository : EFRepositoryBase<Resim, FotografciBulDbContext>, IResimDAL
    {

    }
}
