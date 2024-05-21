namespace GTL.Application.Commands.Author
{
    public class CreateAuthorCommand : ICommand
    {
        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
    }
}
