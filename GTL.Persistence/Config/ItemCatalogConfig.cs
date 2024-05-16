using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class ItemCatalogConfig : IEntityTypeConfiguration<ItemCatalogEntity>
    {
        public void Configure(EntityTypeBuilder<ItemCatalogEntity> builder)
        {
            //builder.ToTable("ItemCatalog", "itemCatalog");
            builder.HasKey(x => x.ItemCatalogId);
            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.SubjectArea);
            builder
                .HasMany(x => x.Items)
                .WithOne(x => x.Catalog)
                .HasForeignKey(f => f.ItemCatalogId);
            builder
                .HasMany(x => x.Authors)
                .WithOne(x => x.Catalog)
                .HasForeignKey(f => f.ItemCatalogId);
        }
    }
}
