﻿using GTL.Domain.Common;
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

        public void Edit()
        {

        }

        public Guid MemberId { get; private set; }
        public MemberEntity Members { get; private set; } // FK

        public Guid ItemCatalogId { get; private set; }
        public ItemCatalogEntity Catalog { get; private set; } // FK

        public DateTime DateReserved { get; private set; }
        public int Amount { get; private set; }
    }
}
