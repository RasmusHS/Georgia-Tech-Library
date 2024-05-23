using GTL.Application.DTO.Author.Query;

namespace GTL.Application.DTO.ItemCatalog.Query
{
    public class QueryItemCatalogDto
    {
        public QueryItemCatalogDto(Guid itemCatalogId, string? isbn, string title, string description, string subjectArea, string type, string? edition, byte[] rowVersion, List<QueryAuthorDto>? authors)
        {
            ItemCatalogId = itemCatalogId;
            ISBN = isbn;
            Title = title;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            RowVersion = rowVersion;
            Authors = authors;
        }

        public QueryItemCatalogDto() { }

        public Guid ItemCatalogId { get; set; }
        public string? ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubjectArea { get; set; }
        public string Type { get; set; }
        public string? Edition { get; set; }
        public byte[] RowVersion { get; set; }
        public List<QueryAuthorDto>? Authors { get; set; }
    }
}
