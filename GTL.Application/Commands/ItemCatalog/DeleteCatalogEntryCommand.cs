namespace GTL.Application.Commands.ItemCatalog
{
    public class DeleteCatalogEntryCommand : ICommand
    {
        public DeleteCatalogEntryCommand(Guid itemCatalogId)
        {
            ItemCatalogId = itemCatalogId;
        }

        public Guid ItemCatalogId { get; set; }
    }
}
