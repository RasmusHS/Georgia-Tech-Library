namespace GTL.Application.Commands.Acquisitions
{
    public class UpdateAcquisitionCommand : ICommand
    {
        public UpdateAcquisitionCommand(Guid memberId, Guid itemCatalogId, DateTime requestDate, int amount, byte[] rowVersion) 
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = requestDate;
            Amount = amount;
            RowVersion = rowVersion;
        }

        public Guid MemberId { get; private set; }
        public Guid ItemCatalogId { get; private set; }
        public DateTime RequestDate { get; private set; }
        public int Amount { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
