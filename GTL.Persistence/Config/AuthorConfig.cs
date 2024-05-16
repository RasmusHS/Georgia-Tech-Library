using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class AuthorConfig : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.ItemCatalogId,
                    x.Name
                });
            builder
                .HasOne(x => x.Catalog)
                .WithMany(x => x.Authors).HasConstraintName("fk_itemcatalog_id");
        }
    }
}
