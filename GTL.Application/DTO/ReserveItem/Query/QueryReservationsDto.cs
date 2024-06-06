namespace GTL.Application.DTO.ReserveItem.Query
{
    public class QueryReservationsDto
    {
        public QueryReservationsDto(Guid memberId, Guid itemCatalogId, DateTime dateReserved, int amount, byte[] rowVersion)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            DateReserved = dateReserved;
            Amount = amount;
            RowVersion = rowVersion;
        }

        public QueryReservationsDto() { }

        public Guid MemberId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public DateTime DateReserved { get; set; }
        public int Amount { get; set; }
        public byte[] RowVersion { get; set; }
}
}
