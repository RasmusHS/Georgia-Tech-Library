namespace GTL.Application.DTO.Book.Query
{
    public class QueryBookDto
    {
        public QueryBookDto(Guid bookId, Guid bookCatalogId, bool isLendable, DateTime dateCreated, string condition)
        {
            BookId = bookId;
            BookCatalogId = bookCatalogId;
            IsLendable = isLendable;
            DateCreated = dateCreated;
            Condition = condition;
        }

        public QueryBookDto() { }

        public Guid BookId { get; set; }
        public Guid BookCatalogId { get; set; }
        public bool IsLendable { get; set; }
        public DateTime DateCreated { get; set; }
        public string Condition { get; set; }
    }
}
