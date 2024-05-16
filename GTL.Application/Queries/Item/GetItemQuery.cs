using GTL.Application.DTO.Item.Query;
using EnsureThat;

namespace GTL.Application.Queries.Item
{
    public class GetItemQuery : IQuery<QueryItemDto>
    {
        public GetItemQuery(Guid itemId) 
        { 
            Ensure.That(itemId, nameof(itemId)).IsNotEmpty();
            ItemId = itemId;
        }

        public Guid ItemId { get; private set; }
    }
}
