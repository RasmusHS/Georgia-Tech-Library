using EnsureThat;

namespace GTL.Application.Commands.Item
{
    public class DeleteItemCommand : ICommand
    {
        public DeleteItemCommand(Guid itemId) 
        { 
            Ensure.That(itemId).IsNotEmpty();
            ItemId = itemId;
        }

        public Guid ItemId { get; private set; }
    }
}
