using GTL.Application.DTO.Acquisitions.Query;
using EnsureThat;

namespace GTL.Application.Queries.Acquisitions
{
    public class GetAcquisitionQuery : IQuery<QueryAcquisitionDto>
    {
        public GetAcquisitionQuery(Guid memberId, Guid itemCatalogId, DateTime requestDate)
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            Ensure.That(requestDate, nameof(requestDate)).IsNotDefault();
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = requestDate;
        }

        public Guid MemberId { get; private set; }
        public Guid ItemCatalogId { get; private set; }
        public DateTime RequestDate { get; private set; }
    }
}
