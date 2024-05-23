using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class AcquisitionEntity : BaseEntity
    {
        public AcquisitionEntity() { }

        private AcquisitionEntity(Guid memberId, Guid itemCatalogId, DateTime requestDate, int amount) 
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = DateTime.Now;
            Amount = amount;
        }

        public static Result<AcquisitionEntity> Create(Guid memberId, Guid itemCatalogId, DateTime requestDate, int amount)
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            Ensure.That(requestDate, nameof(requestDate));
            Ensure.That(amount, nameof(amount)).IsGt(0);
            return Result.Ok(new AcquisitionEntity(memberId, itemCatalogId, requestDate, amount));
        }

        public void Edit(Guid memberId, Guid itemCatalogId, int amount, DateTime requestDate, byte[] rowVersion)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            Amount = amount;
            RequestDate = requestDate;
            RowVersion = rowVersion;
        }

        public Guid MemberId { get; private set; }
        public MemberEntity Members { get; private set; } // FK

        public Guid ItemCatalogId { get; private set; }
        public ItemCatalogEntity Catalog { get; private set; } // FK

        public DateTime RequestDate { get; private set; }
        public int Amount { get; private set; } 
    }
}
