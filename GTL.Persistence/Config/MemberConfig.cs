using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member", "member");
            builder.HasKey(x => x.MemberId);
            builder
                .HasMany(e => e.Books)
                .WithMany(e => e.Members)
                .UsingEntity<BookBorrowings>(
                l => l.HasOne<Book>(e => e.Books).WithMany(e => e.Borrowings),
                r => r.HasOne<Member>(e => e.Members).WithMany(e => e.Borrowings));
        }
    }
}
