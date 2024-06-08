namespace GTL.Application.Commands.ReserveItem
{
    public class CreateReservationCommand : ICommand
    {
        public CreateReservationCommand(Guid memberId, Guid itemCatalogId/*, DateTime dateReserved*/, int amount)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            //DateReserved = dateReserved;
            Amount = amount;
        }

        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        //public DateTime DateReserved { get; set; }
        public int Amount { get; set; }
    }
}
