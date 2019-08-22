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
    public class FotografciService : IFotografciService
    {


        IFotografciDAL _fotografciDAL;

        public FotografciService(IFotografciDAL fotografciDAL)
        {
            _fotografciDAL = fotografciDAL;
        }


        public void Delete(Fotografci entity)
        {
            _fotografciDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Fotografci Get(int entityID)
        {
            return _fotografciDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Fotografci> GetAll()
        {
            return _fotografciDAL.GetAll();
        }

        public Fotografci GetPhotographerByLogin(string mail, string sifre)
        {
            return _fotografciDAL.Get(a => a.Email == mail && a.Sifre == sifre);
        }

        public void Insert(Fotografci entity)
        {
            _fotografciDAL.Add(entity);
        }

        public void Update(Fotografci entity)
        {
            _fotografciDAL.Update(entity);
        }
    }
}
