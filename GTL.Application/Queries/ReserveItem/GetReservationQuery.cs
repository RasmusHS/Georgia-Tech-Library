using GTL.Application.DTO.ReserveItem.Query;
using EnsureThat;

namespace GTL.Application.Queries.ReserveItem
{
    public class GetReservationQuery : IQuery<QueryReservationsDto>
    {
        public GetReservationQuery(Guid memberId, Guid itemCatalogId)
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
        }

        public Guid MemberId { get; private set; }
        public Guid ItemCatalogId { get; private set; }
    }
}
