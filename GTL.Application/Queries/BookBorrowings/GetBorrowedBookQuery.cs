using GTL.Application.DTO.BookBorrowerings.Query;
using EnsureThat;

namespace GTL.Application.Queries.BookBorrowings
{
    public class GetBorrowedBookQuery : IQuery<QueryBookBorrowingsDto>
    {
        public GetBorrowedBookQuery(Guid memberId, Guid bookId) 
        { 
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(bookId, nameof(bookId)).IsNotEmpty();
            MemberId = memberId;
            BookId = bookId;
        }

        public Guid MemberId { get; private set; }
        public Guid BookId { get; private set; }
    }
}
