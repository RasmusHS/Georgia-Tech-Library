namespace GTL.Application.DTO.Item.Query
{
    public class QueryItemDto
    {
        public QueryItemDto(Guid itemId, Guid itemCatalogId, bool isLendable, DateTime dateCreated, string condition, byte[] rowVersion)
        {
            ItemId = itemId;
            ItemCatalogId = itemCatalogId;
            IsLendable = isLendable;
            DateCreated = dateCreated;
            Condition = condition;
            RowVersion = rowVersion;
        }

        public QueryItemDto() { }

        public Guid ItemId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public bool IsLendable { get; set; }
        public DateTime DateCreated { get; set; }
        public string Condition { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
