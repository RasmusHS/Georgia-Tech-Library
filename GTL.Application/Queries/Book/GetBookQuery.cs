using GTL.Application.DTO.Book.Query;
using EnsureThat;

namespace GTL.Application.Queries.Book
{
    public class GetBookQuery : IQuery<QueryBookDto>
    {
        public GetBookQuery(Guid bookId) 
        { 
            Ensure.That(bookId, nameof(bookId)).IsNotEmpty();
            BookId = bookId;
        }

        public Guid BookId { get; private set; }
    }
}
