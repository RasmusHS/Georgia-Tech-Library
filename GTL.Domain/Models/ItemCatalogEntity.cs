using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class ItemCatalogEntity : BaseEntity
    {
        public ItemCatalogEntity() { }

        private ItemCatalogEntity(string? isbn, string title, /*List<string> authors,*/ string description, string subjectArea, string type, string? edition) 
        {
            ItemCatalogId = Guid.NewGuid();
            ISBN = isbn;
            Title = title;
            //Authors = authors;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
        }

        public static Result<ItemCatalogEntity> Create(string? isbn, string title, /*List<string> authors,*/ string description, string subjectArea, string type, string? edition)
        {
            Ensure.That(isbn, nameof(isbn));
            Ensure.That(title, nameof(title)).IsNotNullOrEmpty();
            //Ensure.That(authors, nameof(authors));
            Ensure.That(description, nameof(description)).IsNotNullOrEmpty();
            Ensure.That(subjectArea, nameof(subjectArea)).IsNotNullOrEmpty();
            Ensure.That(type, nameof(type)).IsNotNullOrEmpty();
            Ensure.That(edition, nameof(edition));
            return Result.Ok(new ItemCatalogEntity(isbn, title, /*authors,*/ description, subjectArea, type, edition));
        }

        public void Edit()
        {

        }

        public Guid ItemCatalogId { get; private set; }
        public string? ISBN { get; private set; }
        public string Title { get; private set; }
        //public List<string> Authors { get; private set; }
        public string Description { get; private set; }
        public string SubjectArea { get; private set; }
        public string Type { get; private set; }
        public string? Edition { get; private set; }

        public List<ItemEntity> Items { get; private set; }
        public List<AuthorEntity> Authors { get; private set; }

        public List<ReserveItemEntity> ReservedItems { get; private set; }
        public List<AcquisitionEntity> AcquisitionItems { get; private set;}
    }
}
