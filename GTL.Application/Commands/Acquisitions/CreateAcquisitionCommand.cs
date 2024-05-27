namespace GTL.Application.Commands.Acquisitions
{
    public class CreateAcquisitionCommand : ICommand
    {
        public CreateAcquisitionCommand(Guid memberId, Guid itemCatalogId, DateTime requestDate, int amount)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = requestDate;
            Amount = amount;
        }

        public CreateAcquisitionCommand() { }

        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Amount { get; set; }
    }
}
