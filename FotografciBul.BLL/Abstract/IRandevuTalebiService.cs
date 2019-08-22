using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotografciBul.Model;

namespace FotografciBul.BLL.Abstract
{
   public interface IRandevuTalebiService:IBaseService<RandevuTalebi>
    {
        ICollection<RandevuTalebi> RandevuTarihineGoreSirala();
        ICollection<RandevuTalebi> OnaylanmamisRandevular();
        ICollection<RandevuTalebi> OnaylanmisRandevular();
        ICollection<RandevuTalebi> OlusturulmaTarihineGoreTumRandevular(int fotografciID);

    }
}
