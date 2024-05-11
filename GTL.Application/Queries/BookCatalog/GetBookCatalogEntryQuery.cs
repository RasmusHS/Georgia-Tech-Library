using GTL.Application.DTO.BookCatalog.Query;
using EnsureThat;

namespace GTL.Application.Queries.BookCatalog
{
    public class GetBookCatalogEntryQuery : IQuery<QueryBookCatalogDto>
    {
        public GetBookCatalogEntryQuery(Guid bookCatalogId) 
        {
            Ensure.That(bookCatalogId, nameof(bookCatalogId)).IsNotEmpty();
            BookCatalogId = bookCatalogId;
        }

        public Guid BookCatalogId { get; private set; }
    }
}
