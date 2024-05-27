namespace GTL.Application.Commands.Author
{
    public class CreateAuthorCommand : ICommand
    {
        public CreateAuthorCommand(Guid? itemCatalogId, string name)
        {
            ItemCatalogId = itemCatalogId;
            Name = name;
        }

        public CreateAuthorCommand() { }

        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
    }
}
