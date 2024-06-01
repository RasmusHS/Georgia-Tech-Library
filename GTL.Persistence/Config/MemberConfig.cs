using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class MemberConfig : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            builder.HasKey(x => x.MemberId);
            builder
                .HasMany(x => x.Borrowings)
                .WithOne(x => x.Members)
                .HasForeignKey(x => x.MemberId);
        }
    }
}
