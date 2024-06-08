namespace GTL.Application.Commands.ItemBorrowings
{
    public class DeleteBorrowingCommand : ICommand
    {
        public DeleteBorrowingCommand(Guid memberId, Guid itemId, DateTime startDate)
        {
            MemberId = memberId;
            ItemId = itemId;
            StartDate = startDate;
        }

        public Guid MemberId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
