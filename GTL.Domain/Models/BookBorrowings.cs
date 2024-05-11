using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class BookBorrowings : BaseEntity
    {
        public BookBorrowings() { }
        
        private BookBorrowings(Guid memberId, Guid bookId, DateTime due) 
        { 
            MemberId = memberId;
            BookId = bookId;
            Due = due;
        }

        public static Result<BookBorrowings> Create(Guid memberId, Guid bookId, DateTime due) 
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(bookId, nameof(bookId)).IsNotEmpty();
            Ensure.That(due, nameof(due));
            return Result.Ok(new BookBorrowings(memberId, bookId, due));
        }

        public void Edit()
        {

        }

        public Guid MemberId { get; private set; }
        public Member Members { get; private set; } // FK

        public Guid BookId { get; private set; }
        public Book Books { get; private set; } // FK

        public DateTime Due {  get; private set; }
    }
}
