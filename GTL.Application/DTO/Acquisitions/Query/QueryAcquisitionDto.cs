namespace GTL.Application.DTO.Acquisitions.Query
{
    public class QueryAcquisitionDto
    {
        public QueryAcquisitionDto(Guid itemCatalogId, Guid memberId, DateTime requestDate, int amount, byte[] rowVersion)
        {
            ItemCatalogId = itemCatalogId;
            MemberId = memberId;
            RequestDate = requestDate;
            Amount = amount;
            RowVersion = rowVersion;
        }

        public QueryAcquisitionDto() { }
        public Guid ItemCatalogId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Amount { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
