using GTL.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class Book : BaseEntity
    {
        public Book() { }

        private Book(Guid bookCatalogId, bool isLendable) 
        { 
            BookId = Guid.NewGuid();
            BookCatalogId = bookCatalogId;
            IsLendable = isLendable;
        }

        public static Result<Book> Create(Guid bookCatalogId, bool isLendable) 
        {
            Ensure.That(bookCatalogId, nameof(bookCatalogId)).IsNotEmpty();
            Ensure.That(isLendable, nameof(isLendable));
            return Result.Ok(new Book(bookCatalogId, isLendable));
        }

        public void Edit()
        {

        }

        public Guid BookId { get; private set; }

        public Guid BookCatalogId { get; private set; }
        public BookCatalog Catalog { get; private set; } // FK

        public bool IsLendable { get; private set; }

        // Many-to-many mapping with Member
        public List<BookBorrowings> Borrowings { get; private set;}
        public List<Member> Members { get; private set; }
    }
}
