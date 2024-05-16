using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class ItemBorrowingsEntity : BaseEntity
    {
        public ItemBorrowingsEntity() { }
        
        private ItemBorrowingsEntity(/*MemberEntity members, BookEntity books,*/ Guid memberId, Guid itemId, DateTime due, DateTime startDate, DateTime? returnedDate) 
        { 
            //Members = members;
            //Books = books;
            MemberId = memberId;
            ItemId = itemId;
            Due = due;
            StartDate = startDate;
            ReturnedDate = returnedDate;
        }

        public static Result<ItemBorrowingsEntity> Create(/*MemberEntity members, BookEntity books,*/Guid memberId, Guid itemId, DateTime due, DateTime startDate, DateTime? returnedDate) 
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            Ensure.That(itemId, nameof(itemId)).IsNotEmpty();
            Ensure.That(due, nameof(due));
            Ensure.That(startDate, nameof(startDate));
            Ensure.That(returnedDate, nameof(returnedDate));
            return Result.Ok(new ItemBorrowingsEntity(/*members, books,*/memberId, itemId, due, startDate, returnedDate));
        }

        public void Edit()
        {

        }

        public Guid MemberId { get; private set; }
        public MemberEntity Members { get; private set; } // FK

        public Guid ItemId { get; private set; }
        public ItemEntity Items { get; private set; } // FK

        public DateTime Due {  get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? ReturnedDate { get; private set; }
    }
}
