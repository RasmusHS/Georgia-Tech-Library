using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class ReserveItemConfig : IEntityTypeConfiguration<ReserveItemEntity>
    {
        public void Configure(EntityTypeBuilder<ReserveItemEntity> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.ItemCatalogId,
                    x.MemberId
                });
            builder
                .HasOne(x => x.Members)
                .WithMany(m => m.ReservedItems)
                .HasForeignKey(x => x.MemberId).HasConstraintName("fk_memberid");
            builder
                .HasOne(x => x.Catalog)
                .WithMany(m => m.ReservedItems)
                .HasForeignKey(x => x.ItemCatalogId).HasConstraintName("fk_itemcatalogid");
        }
    }
}
