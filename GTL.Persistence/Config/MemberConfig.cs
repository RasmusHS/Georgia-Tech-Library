using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class MemberConfig : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            builder.ToTable("Member", "member");
            builder.HasKey(x => x.MemberId);
            builder
                .HasMany(e => e.Books)
                .WithMany(e => e.Members)
                .UsingEntity<BookBorrowingsEntity>(
                l => l.HasOne<BookEntity>(e => e.Books).WithMany(e => e.Borrowings),
                r => r.HasOne<MemberEntity>(e => e.Members).WithMany(e => e.Borrowings));
        }
    }
}
