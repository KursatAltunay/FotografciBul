using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FotografciBul.MVC.UI.Models
{
    public class MyRandevu
    {
        private Dictionary<int, RandevuItemDTO> _randevu = new Dictionary<int, RandevuItemDTO>();

        public List<RandevuItemDTO> GetAllRandevuItem
        {
            get
            {
                return _randevu.Values.ToList();
            }
        }

        //public void Add(RandevuItemDTO randevuItemDTO)
        //{
        //    if (_randevu.ContainsKey(randevuItemDTO.ID))
        //    {
        //        _randevu[randevuItemDTO.ID].ID += randevuItemDTO.ID;
        //        return;
        //    }
        //    _randevu.Add(randevuItemDTO.ID, randevuItemDTO);
        //}

        //public void Update(int id, int guncelle)
        //{
        //    if (_randevu.ContainsKey(id))
        //    {
        //        _randevu[id].ID = guncelle;
        //    }
        //}

        public void Delete(int id)
        {
            if (_randevu.ContainsKey(id))
            {
                _randevu.Remove(id);
            }
        }
        //public int fotografciID;
        //public int FotografciID
        //{
        //    get
        //    {
        //        return _randevu.Values.Where(x=>x.FotografciID==fotografciID);
        //    }
        //}
    }
}