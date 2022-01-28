using Biuro_Podrozy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biuro_podrozy_Test
{
    class MemoryBiuroRepository : ICrudDataRepository
    {
        private Dictionary<int, BiuroItem> items = new Dictionary<int, BiuroItem>();
        private int Index = 0;
        private int nextIndex()
        {
           return ++Index;
        }
        public BiuroItem Add(BiuroItem item)
        {
            item.Id = nextIndex();
            items.Add(item.Id, item);
            return item;
        }

        public BiuroItem Delete(int id)
        {
            items.Remove(id);
            return items[id];
        }

        public BiuroItem Find(int id)
        {
            try
            {
                return items[id];
            }
            catch(KeyNotFoundException)
            { 
                return null; 
            }
        }

        public List<BiuroItem> FindAll()
        {
            return items.Values.ToList();
        }

        public BiuroItem Save(BiuroItem item)
        {
            item.Id = nextIndex();
            return item;
        }

        public BiuroItem Update(BiuroItem item)
        {
            throw new NotImplementedException();
        }
    }
}
