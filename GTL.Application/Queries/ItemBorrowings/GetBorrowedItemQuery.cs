using GTL.Application.DTO.ItemBorrowings.Query;
using EnsureThat;

namespace GTL.Application.Queries.ItemBorrowings
{
    public class GetBorrowedItemQuery : IQuery<QueryItemBorrowingsDto>
    {
        public GetBorrowedItemQuery(Guid memberId, Guid itemId, DateTime startDate)
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemId, nameof(itemId)).IsNotEmpty();
            Ensure.That(startDate, nameof(startDate)).IsNotDefault();
            MemberId = memberId;
            ItemId = itemId;
            StartDate = startDate;
        }

        public Guid MemberId { get; private set; }
        public Guid ItemId { get; private set; }
        public DateTime StartDate { get; private set; }
    }
}
