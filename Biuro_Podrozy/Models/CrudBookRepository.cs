using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class CrudBookRepository : ICrudBookRepository
    {
        private ApplicationDbContext _context;
        public CrudBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Add(Book item)
        {
            var bitem = _context.Books.Add(item).Entity;
            _context.SaveChanges();
            return bitem;
        }

        public Book Delete(int id)
        {
            var item = _context.Books.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return item;
        }

        public Book Find(int id)
        {
            return _context.Books.Find(id);
        }

        public Book Save(Book item)
        {
            var bitem = _context.Books.Update(item).Entity;
            _context.SaveChanges();
            return bitem;
        }

        public Book Update(Book item)
        {
            try
            {
                var bitem = _context.Books.Update(item).Entity;
                _context.SaveChanges();
                return bitem;
            }
            catch
            {
                return null;
            }
        }
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }
    }
}
