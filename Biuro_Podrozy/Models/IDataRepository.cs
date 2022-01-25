using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public interface IDataRepository
    {
        IQueryable<BiuroItem> Data { get; }
        IQueryable<DepartureCity> Dc { get; }
        IQueryable<Photo> Ph { get; }
    }
}
