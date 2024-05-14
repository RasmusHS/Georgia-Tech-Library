using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class BookEntity : BaseEntity
    {
        public BookEntity() { }

        private BookEntity(/*BookCatalogEntity catalog*/ Guid bookCatalogId, bool isLendable, DateTime dateCreated, string condition) 
        { 
            BookId = Guid.NewGuid();
            BookCatalogId = bookCatalogId;
            //Catalog = catalog;
            IsLendable = isLendable;
        }

        public static Result<BookEntity> Create(/*BookCatalogEntity catalog*/ Guid bookCatalogId, bool isLendable, DateTime dateCreated, string condition) 
        {
            Ensure.That(bookCatalogId, nameof(bookCatalogId)).IsNotEmpty();
            Ensure.That(isLendable, nameof(isLendable));
            Ensure.That(dateCreated, nameof(dateCreated));
            Ensure.That(condition, nameof(condition)).IsNotNullOrEmpty();
            return Result.Ok(new BookEntity(/*catalog*/ bookCatalogId, isLendable, dateCreated, condition));
        }

        public void Edit()
        {

        }

        public Guid BookId { get; private set; }

        public Guid BookCatalogId { get; private set; }
        public BookCatalogEntity Catalog { get; private set; } // FK

        public bool IsLendable { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Condition { get; private set; }

        // Many-to-many mapping with Member
        public List<BookBorrowingsEntity> Borrowings { get; private set;}
        public List<MemberEntity> Members { get; private set; }
    }
}
