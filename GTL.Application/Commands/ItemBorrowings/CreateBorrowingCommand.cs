namespace GTL.Application.Commands.ItemBorrowings
{
    public class CreateBorrowingCommand : ICommand
    {
        public CreateBorrowingCommand(Guid memberId, Guid itemId, DateTime startDate, DateTime due, DateTime? returnedDate)
        {
            MemberId = memberId;
            ItemId = itemId;
            StartDate = startDate;
            Due = due;
            ReturnedDate = returnedDate;
        }

        public Guid MemberId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Due { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
