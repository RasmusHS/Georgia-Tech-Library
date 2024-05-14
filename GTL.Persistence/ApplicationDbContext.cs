using GTL.Application.Data;
using GTL.Domain.Models;
using GTL.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace GTL.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<BookEntity> BookEntities { get; set; }
        public DbSet<BookBorrowingsEntity> BookBorrowingEntities { get; set; }
        public DbSet<BookCatalogEntity> BookCatalogEntities { get; set; }
        public DbSet<MemberEntity> MemberEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder
                .ApplyConfiguration(new MemberConfig())
                .ApplyConfiguration(new BookCatalogConfig())
                .ApplyConfiguration(new BookConfig());
        }
    }
}
