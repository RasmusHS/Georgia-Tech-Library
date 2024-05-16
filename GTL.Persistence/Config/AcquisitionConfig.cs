using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class AcquisitionConfig : IEntityTypeConfiguration<AcquisitionEntity>
    {
        public void Configure(EntityTypeBuilder<AcquisitionEntity> builder)
        {
            builder
                .HasKey(x => new
                {
                    x.MemberId,
                    x.ItemCatalogId,
                    x.RequestDate
                });
            builder
                .HasOne(x => x.Members)
                .WithMany(m => m.AcquisitionItems)
                .HasForeignKey(x => x.MemberId).HasConstraintName("fk_member_id");
            builder
                .HasOne(x => x.Catalog)
                .WithMany(m => m.AcquisitionItems)
                .HasForeignKey(x => x.ItemCatalogId).HasConstraintName("fk_item_catalogid");
        }
    }
}
