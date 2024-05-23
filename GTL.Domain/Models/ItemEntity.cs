using GTL.Domain.Common;
using EnsureThat;

namespace GTL.Domain.Models
{
    public class ItemEntity : BaseEntity
    {
        public ItemEntity() { }

        private ItemEntity(Guid itemCatalogId, bool isLendable, DateTime dateCreated, string condition) 
        { 
            ItemId = Guid.NewGuid();
            ItemCatalogId = itemCatalogId;
            IsLendable = isLendable;
            DateCreated = DateTime.Now;
            Condition = condition;
        }

        public static Result<ItemEntity> Create(Guid itemCatalogId, bool isLendable, DateTime dateCreated, string condition) 
        {
            Ensure.That(itemCatalogId, nameof(itemCatalogId)).IsNotEmpty();
            Ensure.That(isLendable, nameof(isLendable));
            Ensure.That(dateCreated, nameof(dateCreated));
            Ensure.That(condition, nameof(condition)).IsNotNullOrEmpty();
            return Result.Ok(new ItemEntity(itemCatalogId, isLendable, dateCreated, condition));
        }

        public void Edit(Guid itemCatalogId, bool isLendable, DateTime dateCreated, string condition, byte[] rowVersion)
        {
            ItemCatalogId = itemCatalogId;
            IsLendable = isLendable;
            DateCreated = dateCreated;
            Condition = condition;
            RowVersion = rowVersion;
        }

        public Guid ItemId { get; private set; }

        public Guid ItemCatalogId { get; private set; }
        public ItemCatalogEntity Catalog { get; private set; } // FK

        public bool IsLendable { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Condition { get; private set; }

        // Many-to-many mapping with Member
        public List<ItemBorrowingsEntity> Borrowings { get; private set;}
        //public List<MemberEntity> Members { get; private set; }
    }
}
