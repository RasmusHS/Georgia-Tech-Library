using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class BookBorrowingsEntity : BaseEntity
    {
        public BookBorrowingsEntity() { }
        
        private BookBorrowingsEntity(/*MemberEntity members, BookEntity books,*/ Guid memberId, Guid bookId, DateTime due, DateTime startDate, DateTime? returnedDate) 
        { 
            //Members = members;
            //Books = books;
            MemberId = memberId;
            BookId = bookId;
            Due = due;
            StartDate = startDate;
            ReturnedDate = returnedDate;
        }

        public static Result<BookBorrowingsEntity> Create(/*MemberEntity members, BookEntity books,*/Guid memberId, Guid bookId, DateTime due, DateTime startDate, DateTime? returnedDate) 
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(bookId, nameof(bookId)).IsNotEmpty();
            Ensure.That(due, nameof(due));
            Ensure.That(startDate, nameof(startDate));
            Ensure.That(returnedDate, nameof(returnedDate));
            return Result.Ok(new BookBorrowingsEntity(/*members, books,*/memberId, bookId, due, startDate, returnedDate));
        }

        public void Edit()
        {

        }

        public Guid MemberId { get; private set; }
        public MemberEntity Members { get; private set; } // FK

        public Guid BookId { get; private set; }
        public BookEntity Books { get; private set; } // FK

        public DateTime Due {  get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? ReturnedDate { get; private set; }
    }
}
