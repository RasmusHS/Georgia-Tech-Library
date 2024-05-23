namespace GTL.Application.Commands.Acquisitions
{
    public class CreateAcquisitionCommand : ICommand
    {
        //public CreateAcquisitionCommand(Guid itemCatalogId, Guid memberId, DateTime requestDate, int amount) 
        //{
        //    ItemCatalogId = itemCatalogId;
        //    MemberId = memberId;
        //    RequestDate = requestDate;
        //    Amount = amount;
        //}

        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Amount { get; set; }
    }
}
