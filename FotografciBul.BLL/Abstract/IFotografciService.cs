using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.Model;

namespace FotografciBul.BLL.Abstract
{
  public interface IFotografciService:IBaseService<Fotografci>
    {
        Fotografci GetPhotographerByLogin(string adi, string sifre);
    }
}
