using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class BookBorrowingsConfig : IEntityTypeConfiguration<BookBorrowings>
    {
        public void Configure(EntityTypeBuilder<BookBorrowings> builder)
        {
            builder
                .HasKey(x => new 
                { 
                    x.MemberId, 
                    x.BookId 
                });
        }
    }
}
