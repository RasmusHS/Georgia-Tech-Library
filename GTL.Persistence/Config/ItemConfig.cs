using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class ItemConfig : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            //builder.ToTable("Item", "item");
            builder.HasKey(x => x.ItemId);
            builder
                .HasOne(x => x.Catalog)
                .WithMany(x => x.Items).HasConstraintName("fkitem_catalog_id");
            builder
                .HasMany(x => x.Borrowings)
                .WithOne(x => x.Items)
                .HasForeignKey(x => x.ItemId);
        }
    }
}
