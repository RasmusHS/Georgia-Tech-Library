using GTL.Application.DTO.Author.Query;
using EnsureThat;

namespace GTL.Application.Queries.Author
{
    public class GetAuthorQuery : IQuery<QueryAuthorDto>
    {
        public GetAuthorQuery(Guid? itemCatalogId, string name)
        {
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotNull();
            Ensure.That(name, nameof(name)).IsNotEmpty();
            ItemCatalogId = itemCatalogId;
            Name = name;
        }

        public Guid? ItemCatalogId { get; private set; }
        public string Name { get; private set; }
    }
}
