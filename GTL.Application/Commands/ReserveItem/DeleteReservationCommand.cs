namespace GTL.Application.Commands.ReserveItem
{
    public class DeleteReservationCommand : ICommand
    {
        public DeleteReservationCommand(Guid memberId, Guid itemCatalogId)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
        }

        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
    }
}
