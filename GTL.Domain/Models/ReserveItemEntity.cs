using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class ReserveItemEntity : BaseEntity
    {
        public ReserveItemEntity() { }

        private ReserveItemEntity(Guid memberId, Guid itemCatalogId, int amount)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            DateReserved = DateTime.Now;
            Amount = amount;
        }

        public static Result<ReserveItemEntity> Create(Guid memberId, Guid itemCatalogId, int amount)
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            Ensure.That(amount, nameof(amount)).IsGt(0);
            return Result.Ok(new ReserveItemEntity(memberId, itemCatalogId, amount));
        }

        public void Edit(Guid memberId, Guid itemCatalogId, DateTime dateReserved, int amount, byte[] rowVersion)
        {
            MemberId = memberId;
            ItemCatalogId = itemCatalogId;
            DateReserved = dateReserved;
            Amount = amount;
            RowVersion = rowVersion;
        }

        public Guid MemberId { get; set; }
        public MemberEntity Members { get; private set; } // FK

        public Guid ItemCatalogId { get; set; }
        public ItemCatalogEntity Catalog { get; private set; } // FK

        public DateTime DateReserved { get; set; }
        public int Amount { get; set; }
    }
}
