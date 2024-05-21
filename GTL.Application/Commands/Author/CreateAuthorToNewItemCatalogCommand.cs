namespace GTL.Application.Commands.Author
{
    public class CreateAuthorToNewItemCatalogCommand
    {
        //public CreateAuthorToNewItemCatalogCommand(Guid? itemCatalogId, string name)
        //{
        //    ItemCatalogId = itemCatalogId;
        //    Name = name;
        //}

        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
    }
}
