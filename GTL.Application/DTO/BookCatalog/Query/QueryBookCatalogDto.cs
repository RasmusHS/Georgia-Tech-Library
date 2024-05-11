namespace GTL.Application.DTO.BookCatalog.Query
{
    public class QueryBookCatalogDto
    {
        public QueryBookCatalogDto(Guid bookCatalogId, string isbn, string title, List<string> authors, string description, string subjectArea, string type, string edition, bool isAvailable)
        {
            BookCatalogId = bookCatalogId;
            ISBN = isbn;
            Title = title;
            Authors = authors;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            IsAvailable = isAvailable;
        }

        public QueryBookCatalogDto() { }

        public Guid BookCatalogId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Description { get; set; }
        public string SubjectArea { get; set; }
        public string Type { get; set; }
        public string Edition { get; set; }
        public bool IsAvailable { get; set; }
    }
}
