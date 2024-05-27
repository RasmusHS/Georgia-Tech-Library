namespace GTL.Application.Commands.Item
{
    public class UpdateItemCommand : ICommand
    {
        public UpdateItemCommand(Guid itemId, Guid itemCatalogId, bool isLendable, DateTime dateCreated, string condition, byte[] rowVersion)
        {
            ItemId = itemId;
            ItemCatalogId = itemCatalogId;
            IsLendable = isLendable;
            DateCreated = dateCreated;
            Condition = condition;
            RowVersion = rowVersion;
        }

        public Guid ItemId { get; private set; }
        public Guid ItemCatalogId { get; private set; }
        public bool IsLendable { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Condition { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
