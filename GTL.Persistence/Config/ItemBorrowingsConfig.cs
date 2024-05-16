using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class ItemBorrowingsConfig : IEntityTypeConfiguration<ItemBorrowingsEntity>
    {
        public void Configure(EntityTypeBuilder<ItemBorrowingsEntity> builder)
        {
            builder
                .HasKey(x => new 
                { 
                    x.MemberId, 
                    x.ItemId,
                    x.StartDate
                });
            builder
                .HasOne(x => x.Members)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(x => x.MemberId).HasConstraintName("fkmember_id");
            builder
                .HasOne(x => x.Items)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(x => x.ItemId).HasConstraintName("fk_item_id");
        }
    }
}
