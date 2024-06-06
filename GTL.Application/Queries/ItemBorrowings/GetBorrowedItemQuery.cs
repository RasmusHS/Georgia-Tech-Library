using GTL.Application.DTO.ItemBorrowings.Query;
using EnsureThat;

namespace GTL.Application.Queries.ItemBorrowings
{
    public class GetBorrowedItemQuery : IQuery<QueryItemBorrowingsDto>
    {
        public GetBorrowedItemQuery(Guid memberId, Guid itemId) 
        { 
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemId, nameof(itemId)).IsNotEmpty();
            MemberId = memberId;
            ItemId = itemId;
        }

        public Guid MemberId { get; private set; }
        public Guid ItemId { get; private set; }
    }
}
