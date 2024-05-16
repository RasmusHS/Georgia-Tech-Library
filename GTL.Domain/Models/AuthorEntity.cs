using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class AuthorEntity : BaseEntity
    {
        public AuthorEntity() { }

        private AuthorEntity(Guid catalogId, string name)
        {
            ItemCatalogId = catalogId;
            Name = name;
        }

        public static Result<AuthorEntity> Create(Guid catalogId, string name)
        {
            Ensure.That(catalogId, nameof(catalogId)).IsNotEmpty();
            Ensure.That(name, nameof(name)).IsNotNullOrEmpty();
            return Result.Ok(new AuthorEntity(catalogId, name));
        }

        public void Edit()
        {

        }

        public Guid ItemCatalogId { get; private set; }
        public ItemCatalogEntity Catalog { get; private set; }

        public string Name { get; private set; }
    }
}
