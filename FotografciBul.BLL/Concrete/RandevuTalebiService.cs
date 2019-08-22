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
    public class RandevuTalebiService : IRandevuTalebiService
    {
        IRandevuTalebiDAL _randevuTalebiDAL;

        public RandevuTalebiService(IRandevuTalebiDAL randevuTalebiDAL)
        {
            _randevuTalebiDAL = randevuTalebiDAL;
        }


        public void Delete(RandevuTalebi entity)
        {
            _randevuTalebiDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public RandevuTalebi Get(int entityID)
        {
            return _randevuTalebiDAL.Get(a => a.ID == entityID);
        }

        public ICollection<RandevuTalebi> GetAll()
        {
            return _randevuTalebiDAL.GetAll();
        }

        public void Insert(RandevuTalebi entity)
        {
            _randevuTalebiDAL.Add(entity);
        }

        

        public ICollection<RandevuTalebi> OnaylanmamisRandevular()
        {
            return _randevuTalebiDAL.GetAll(a => a.OnayDurumu == false);
        }

        public ICollection<RandevuTalebi> OnaylanmisRandevular()
        {
            return _randevuTalebiDAL.GetAll(a => a.OnayDurumu == true);
        }

        public ICollection<RandevuTalebi> RandevuTarihineGoreSirala()
        {
            return _randevuTalebiDAL.GetAll().OrderBy(a=>a.RandevuTarihi).ToList();
        }

        public ICollection<RandevuTalebi> OlusturulmaTarihineGoreTumRandevular(int fotografciID)
        {
            return _randevuTalebiDAL.GetAll(a => a.ID == fotografciID).OrderByDescending(a => a.OlusturulmaTarihi).ToList();
        }

        public void Update(RandevuTalebi entity)
        {
            _randevuTalebiDAL.Update(entity);
        }
    }
}
