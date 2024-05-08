using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.ValueObjects
{
    public class Book : ValueObject
    {
        public Book() { }

        private Book(string isbn_No, string title, string language, string format, string resume, List<string> genre, List<string> authors, string? edition)
        {
            ISBN_No = isbn_No;
            Title = title;
            Language = language;
            Format = format;
            Resume = resume;
            Genre = genre;
            Authors = authors;
            Edition = edition;
        }

        public string ISBN_No { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Format { get; set; }
        public string Resume { get; set; }
        public List<string> Genre { get; set; }
        public List<string> Authors { get; set; }
        public string? Edition { get; set; }

        public static Result<Book> Create(string isbn_No, string title, string language, string format, string resume, List<string> genre, List<string> authors, string? edition)
        {
            Ensure.That(isbn_No, nameof(isbn_No)).IsNotNullOrEmpty();
            Ensure.That(title, nameof(title)).IsNotNullOrEmpty();
            Ensure.That(language, nameof(language)).IsNotNullOrEmpty();
            Ensure.That(format, nameof(format)).IsNotNullOrEmpty();
            Ensure.That(resume, nameof(resume)).IsNotNullOrEmpty();
            Ensure.That(genre, nameof(genre));
            Ensure.That(authors, nameof(authors));
            Ensure.That(edition, nameof(edition));
            return Result.Ok(new Book(isbn_No, title, language, format, resume, genre, authors, edition));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            //throw new NotImplementedException();
            yield return ISBN_No;
            yield return Title;
            yield return Language;
            yield return Format;
            yield return Resume;
            yield return Genre;
            yield return Authors;
            yield return Edition;
        }
    }
}
