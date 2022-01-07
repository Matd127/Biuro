using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class CrudDataRepository : ICrudDataRepository
    {
        private ApplicationDbContext _context;

        public CrudDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BiuroItem Find(int id)
        {
            return _context.Data.Find(id);
        }

        public BiuroItem Delete(int id)
        {
            var biuroitem = _context.Data.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return biuroitem;
        }

        public BiuroItem Add(BiuroItem item)
        {
            var bitem = _context.Data.Add(item).Entity;
            _context.SaveChanges();
            return bitem;
        }

        public BiuroItem Update(BiuroItem item)
        {
            try {
                var bitem = _context.Data.Update(item).Entity;
                _context.SaveChanges();
                return bitem;
            }
            catch
            {
                return null;
            }
        }

        public BiuroItem Save(BiuroItem item)
        {
            var bitem = _context.Data.Update(item).Entity;
            _context.SaveChanges();
            return bitem;

        }

        public List<BiuroItem> FindAll()
        {
            return _context.Data.ToList();
        }


    }
}
