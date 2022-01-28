using Microsoft.EntityFrameworkCore;
using Biuro_Podrozy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiuroItem>()
                 .HasMany<DepartureCity>(b => b.DepartureCities)
                 .WithMany(d => d.BiuroItems);

            modelBuilder.Entity<DepartureCity>()
                .HasMany<BiuroItem>(b => b.BiuroItems)
                .WithMany(d => d.DepartureCities);

            modelBuilder.Entity<BiuroItem>()
                .HasOne<Photo>(p => p.Photos)
                .WithMany(b => b.BiuroItems);

            modelBuilder.Entity<Photo>()
                .HasMany<BiuroItem>(p => p.BiuroItems)
                .WithOne(b => b.Photos);

            modelBuilder.Entity<Book>()
                .HasOne<BiuroItem>(b => b.BiuroItem)
                .WithMany(c => c.Books);

            modelBuilder.Entity<BiuroItem>()
                .HasMany<Book>(b => b.Books)
                .WithOne(c => c.BiuroItem);

        }

        public DbSet<BiuroItem> Data { get; set; }
        public DbSet<DepartureCity> Dc { get; set; }
        public DbSet<Photo> Ph { get; set; }
        public DbSet<Book> Books { get; set; }

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
        public IQueryable<Photo> Ph => _applicationDbContext.Ph;
        public IQueryable<Book> Books => _applicationDbContext.Books;
    } 
}
