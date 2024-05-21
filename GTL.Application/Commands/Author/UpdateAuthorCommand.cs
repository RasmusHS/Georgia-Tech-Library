namespace GTL.Application.Commands.Author
{
    public class UpdateAuthorCommand : ICommand
    {
        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
