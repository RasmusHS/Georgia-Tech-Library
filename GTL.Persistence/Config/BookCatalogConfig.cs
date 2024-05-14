using GTL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTL.Persistence.Config
{
    public class BookCatalogConfig : IEntityTypeConfiguration<BookCatalogEntity>
    {
        public void Configure(EntityTypeBuilder<BookCatalogEntity> builder)
        {
            builder.ToTable("BookCatalog", "bookCatalog");
            builder.HasKey(x => x.BookCatalogId);
            builder.HasIndex(x => x.ISBN);
            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.Authors);
            builder.HasIndex(x => x.SubjectArea);
        }
    }
}
