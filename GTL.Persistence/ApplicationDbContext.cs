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

        public DbSet<AcquisitionEntity> AcquisitionEntities { get; set; }
        public DbSet<AuthorEntity> AuthorEntities { get; set; }
        public DbSet<ItemBorrowingsEntity> ItemBorrowingEntities { get; set; }
        public DbSet<ItemCatalogEntity> ItemCatalogEntities { get; set; }
        public DbSet<ItemEntity> ItemEntities { get; set; }
        public DbSet<MemberEntity> MemberEntities { get; set; }
        public DbSet<ReserveItemEntity> ReserveItemEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder
            //    .ApplyConfiguration(new MemberConfig())
            //    .ApplyConfiguration(new BookCatalogConfig())
            //    .ApplyConfiguration(new BookConfig());
        }
    }
}
