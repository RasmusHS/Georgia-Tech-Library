namespace GTL.Application.DTO.BookBorrowerings.Query
{
    public class QueryBookBorrowingsDto
    {
        public QueryBookBorrowingsDto(Guid memberId, Guid bookId, DateTime due, DateTime startDate, DateTime? returnedDate)
        {
            MemberId = memberId;
            BookId = bookId;
            Due = due;
            StartDate = startDate;
            ReturnedDate = returnedDate;
        }

        public QueryBookBorrowingsDto() { }

        public Guid MemberId { get; set; }
        public Guid BookId { get; set; }
        public DateTime Due { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
