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
    public class KullaniciService:IKullaniciService
    {
        IKullaniciDAL _kullaniciDAL;
        public KullaniciService(IKullaniciDAL kullaniciDAL)
        {
            _kullaniciDAL = kullaniciDAL;
        }
        public void Delete(Kullanici entity)
        {
            _kullaniciDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Kullanici Get(int entityID)
        {
            return _kullaniciDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Kullanici> GetAll()
        {
            return _kullaniciDAL.GetAll();
        }

        public Kullanici GirisIcinKullanici(string kullaniciAdi, string sifre)
        {
            return _kullaniciDAL.Get(a => a.Adi == kullaniciAdi && a.Sifre == sifre);
        }

        public void Insert(Kullanici entity)
        {
            _kullaniciDAL.Add(entity);
        }

        public void Update(Kullanici entity)
        {
            _kullaniciDAL.Update(entity);
        }

        public Kullanici GetUserByLogin(string mail, string sifre)
        {
            return _kullaniciDAL.Get(a => a.Email == mail && a.Sifre == sifre);
        }
        
    }
}
