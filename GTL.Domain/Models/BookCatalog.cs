using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class BookCatalog : BaseEntity
    {
        public BookCatalog() { }

        private BookCatalog(string isbn, string title, List<string> authors, string description, string subjectArea, string type, string edition, bool isAvailable) 
        {
            BookCatalogId = Guid.NewGuid();
            ISBN = isbn;
            Title = title;
            Authors = authors;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            IsAvailable = isAvailable;
        }

        public static Result<BookCatalog> Create(string isbn, string title, List<string> authors, string description, string subjectArea, string type, string edition, bool isAvailable)
        {
            Ensure.That(isbn, nameof(isbn)).IsNotNullOrEmpty();
            Ensure.That(title, nameof(title)).IsNotNullOrEmpty();
            Ensure.That(authors, nameof(authors));
            Ensure.That(description, nameof(description)).IsNotNullOrEmpty();
            Ensure.That(subjectArea, nameof(subjectArea)).IsNotNullOrEmpty();
            Ensure.That(type, nameof(type)).IsNotNullOrEmpty();
            Ensure.That(edition, nameof(edition)).IsNotNullOrEmpty();
            Ensure.That(isAvailable, nameof(isAvailable));
            return Result.Ok(new BookCatalog(isbn, title, authors, description, subjectArea, type, edition, isAvailable));
        }

        public void Edit()
        {

        }

        public Guid BookCatalogId { get; private set; }
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public List<string> Authors { get; private set; }
        public string Description { get; private set; }
        public string SubjectArea { get; private set; }
        public string Type { get; private set; }
        public string Edition { get; private set; }
        public bool IsAvailable { get; private set; }

        public List<Book> Books { get; private set; }
    }
}
