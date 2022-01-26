using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public interface ICrudBookRepository
    {
        Book Find(int id);
        Book Delete(int id);
        Book Add(Book item);
        Book Update(Book item);
        Book Save(Book item);
        List<Book> FindAll();
    }

    
}
