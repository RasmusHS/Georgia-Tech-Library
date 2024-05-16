namespace GTL.Application.DTO.ItemBorrowerings.Query
{
    public class QueryItemBorrowingsDto
    {
        public QueryItemBorrowingsDto(Guid memberId, Guid itemId, DateTime due, DateTime startDate, DateTime? returnedDate)
        {
            MemberId = memberId;
            ItemId = itemId;
            Due = due;
            StartDate = startDate;
            ReturnedDate = returnedDate;
        }

        public QueryItemBorrowingsDto() { }

        public Guid MemberId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime Due { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
