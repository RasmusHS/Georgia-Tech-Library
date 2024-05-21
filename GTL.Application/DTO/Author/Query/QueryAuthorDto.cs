namespace GTL.Application.DTO.Author.Query
{
    public class QueryAuthorDto
    {
        public QueryAuthorDto(Guid? itemCatalogId, string name)
        {
            ItemCatalogId = itemCatalogId;
            Name = name;
        }

        public QueryAuthorDto() { }

        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
    }
}
