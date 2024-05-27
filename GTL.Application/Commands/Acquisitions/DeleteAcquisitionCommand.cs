namespace GTL.Application.Commands.Acquisitions
{
    public class DeleteAcquisitionCommand : ICommand
    {
        public DeleteAcquisitionCommand(Guid memberId, Guid itemCatalogId, DateTime requestDate)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = requestDate;
        }

        public Guid MemberId { get; private set; }
        public Guid ItemCatalogId { get; private set; }
        public DateTime RequestDate { get; private set; }
    }
}
