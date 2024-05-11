namespace GTL.Application.DTO.BookBorrowerings.Query
{
    public class QueryBookBorrowingsDto
    {
        public QueryBookBorrowingsDto(Guid memberId, Guid bookId, DateTime due)
        {
            MemberId = memberId;
            BookId = bookId;
            Due = due;
        }

        public QueryBookBorrowingsDto() { }

        public Guid MemberId { get; set; }
        public Guid BookId { get; set; }
        public DateTime Due { get; set; }
    }
}
