using EnsureThat;
using GTL.Domain.Common;

namespace GTL.Domain.Models
{
    public class AcquisitionEntity
    {
        public AcquisitionEntity() { }

        private AcquisitionEntity(Guid memberId, Guid itemCatalogId, int amount) 
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            RequestDate = DateTime.Now;
            Amount = amount;
        }

        public static Result<AcquisitionEntity> Create(Guid memberId, Guid itemCatalogId, int amount)
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            Ensure.That(amount, nameof(amount)).IsGt(0);
            return Result.Ok(new AcquisitionEntity(memberId, itemCatalogId, amount));
        }

        public Guid ItemCatalogId { get; private set; }
        public ItemCatalogEntity Catalog { get; private set; } // FK

        public Guid MemberId { get; private set; }
        public MemberEntity Members { get; private set; } // FK

        public DateTime RequestDate { get; private set; }
        public int Amount { get; private set; } 
    }
}
