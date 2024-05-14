using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class BookBorrowingsConfig : IEntityTypeConfiguration<BookBorrowingsEntity>
    {
        public void Configure(EntityTypeBuilder<BookBorrowingsEntity> builder)
        {
            builder
                .HasKey(x => new 
                { 
                    x.Members, 
                    x.Books 
                });
        }
    }
}
