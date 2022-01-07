using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public interface ICrudDataRepository
    {
        BiuroItem Find(int id);
        BiuroItem Delete(int id);
        BiuroItem Add(BiuroItem item);
        BiuroItem Update(BiuroItem item);
        BiuroItem Save(BiuroItem item);
        List<BiuroItem> FindAll();
    }
}
