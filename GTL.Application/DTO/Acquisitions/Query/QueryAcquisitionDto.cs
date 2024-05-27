namespace GTL.Application.DTO.Acquisitions.Query
{
    public class QueryAcquisitionDto
    {
        public QueryAcquisitionDto(Guid memberId, Guid itemCatalogId, DateTime requestDate, int amount, byte[] rowVersion)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = requestDate;
            Amount = amount;
            RowVersion = rowVersion;
        }

        public QueryAcquisitionDto() { }
        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime RequestDate { get; set; }
        public int Amount { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
