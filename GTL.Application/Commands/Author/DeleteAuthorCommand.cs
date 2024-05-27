using EnsureThat;

namespace GTL.Application.Commands.Author
{
    public class DeleteAuthorCommand : ICommand
    {
        public DeleteAuthorCommand(Guid? itemCatalogId, string name) 
        {
            Ensure.That(itemCatalogId).IsNotNull();
            Ensure.That(name).IsNotNullOrEmpty();
            ItemCatalogId = itemCatalogId;
            Name = name;
        }

        public Guid? ItemCatalogId { get; set; }
        public string Name { get; set; }
    }
}
