using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class ItemBorrowingsEntity : BaseEntity
    {
        public ItemBorrowingsEntity() { }
        
        private ItemBorrowingsEntity(Guid memberId, Guid itemId, DateTime due, DateTime startDate, DateTime? returnedDate) 
        { 
            MemberId = memberId;
            ItemId = itemId;
            Due = due;
            StartDate = startDate;
            ReturnedDate = returnedDate;
        }

        public static Result<ItemBorrowingsEntity> Create(Guid memberId, Guid itemId, DateTime due, DateTime startDate, DateTime? returnedDate) 
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemId, nameof(itemId)).IsNotEmpty();
            Ensure.That(due, nameof(due));
            Ensure.That(startDate, nameof(startDate));
            Ensure.That(returnedDate, nameof(returnedDate));
            return Result.Ok(new ItemBorrowingsEntity(memberId, itemId, due, startDate, returnedDate));
        }

        public void Edit(Guid memberId, Guid itemId, DateTime due, DateTime startDate, DateTime? returnedDate, byte[] rowVersion)
        {
            MemberId = memberId;
            ItemId = itemId;
            Due = due;
            StartDate = startDate;
            ReturnedDate = returnedDate;
            RowVersion = rowVersion;
        }

        public Guid MemberId { get; set; }
        public MemberEntity Members { get; private set; } // FK

        public Guid ItemId { get; set; }
        public ItemEntity Items { get; private set; } // FK

        public DateTime StartDate { get; set; }
        public DateTime Due { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
