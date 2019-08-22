using FotografciBul.BLL.Abstract;
using FotografciBul.DAL.Abstract;
using FotografciBul.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotografciBul.BLL.Concrete
{
    public class ResimService : IResimService
    {
        IResimDAL _resimDAL;

        public ResimService(IResimDAL resimDAL)
        {
            _resimDAL = resimDAL;
        }


        public void Delete(Resim entity)
        {
            _resimDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Resim Get(int entityID)
        {
            return _resimDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Resim> GetAll()
        {
            return _resimDAL.GetAll();

        }

        public void Insert(Resim entity)
        {
            _resimDAL.Add(entity);
        }

        public void Update(Resim entity)
        {
            _resimDAL.Update(entity);
        }
    }
}
