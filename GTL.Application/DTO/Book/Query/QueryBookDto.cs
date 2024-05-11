namespace GTL.Application.DTO.Book.Query
{
    public class QueryBookDto
    {
        public QueryBookDto(Guid bookId, Guid bookCatalogId, bool isLendable)
        {
            BookId = bookId;
            BookCatalogId = bookCatalogId;
            IsLendable = isLendable;
        }

        public QueryBookDto() { }

        public Guid BookId { get; set; }
        public Guid BookCatalogId { get; set; }
        public bool IsLendable { get; set; }
    }
}
