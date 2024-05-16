using GTL.Application.DTO.ItemCatalog.Query;
using EnsureThat;

namespace GTL.Application.Queries.ItemCatalog
{
    public class GetItemCatalogEntryQuery : IQuery<QueryItemCatalogDto>
    {
        public GetItemCatalogEntryQuery(Guid itemCatalogId) 
        {
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            ItemCatalogId = itemCatalogId;
        }

        public Guid ItemCatalogId { get; private set; }
    }
}
