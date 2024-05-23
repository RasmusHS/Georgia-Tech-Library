namespace GTL.Application.DTO.Author.Query
{
    public class QueryAuthorDto
    {
        public QueryAuthorDto(Guid? itemCatalogId, string name, byte[] rowVersion)
        {
            ItemCatalogId = itemCatalogId;
            Name = name;
            RowVersion = rowVersion;
        }

        public QueryAuthorDto() { }

        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
