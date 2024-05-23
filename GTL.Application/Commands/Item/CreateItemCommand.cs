namespace GTL.Application.Commands.Item
{
    public class CreateItemCommand : ICommand
    {
        //public CreateItemCommand(Guid itemCatalogId, bool isLendable, DateTime dateCreated, string condition)
        //{
        //    ItemCatalogId = itemCatalogId;
        //    IsLendable = isLendable;
        //    DateCreated = dateCreated;
        //    Condition = condition;
        //}

        public Guid ItemCatalogId { get; set; }
        public bool IsLendable { get; set; }
        public DateTime DateCreated { get; set; }
        public string Condition { get; set; }
    }
}
