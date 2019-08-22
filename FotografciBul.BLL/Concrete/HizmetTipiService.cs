using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.BLL.Abstract;
using FotografciBul.DAL.Abstract;
using FotografciBul.Model;

namespace FotografciBul.BLL.Concrete
{
    public class HizmetTipiService : IHizmetTipiService
    {
        IHizmetTipiDAL _hizmetTipiDAL;

        public HizmetTipiService(IHizmetTipiDAL hizmetTipiDAL)
        {
            _hizmetTipiDAL = hizmetTipiDAL;
        }
        public void Delete(HizmetTipi entity)
        {
            _hizmetTipiDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public HizmetTipi Get(int entityID)
        {
            return Get(entityID);
        }

        public ICollection<HizmetTipi> GetAll()
        {
            return _hizmetTipiDAL.GetAll();
        }

        public void Insert(HizmetTipi entity)
        {
            _hizmetTipiDAL.Add(entity);
        }

        public void Update(HizmetTipi entity)
        {
            _hizmetTipiDAL.Update(entity);
        }
    }
}
