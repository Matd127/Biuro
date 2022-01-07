using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BiuroItem> Data { get; set; }
        public DbSet<DepartureCity> Dc { get; set; }
    }

    public class EFPDataRepository : IDataRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public EFPDataRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<BiuroItem> Data => _applicationDbContext.Data;
        public IQueryable<DepartureCity> Dc => _applicationDbContext.Dc;
    }
}
