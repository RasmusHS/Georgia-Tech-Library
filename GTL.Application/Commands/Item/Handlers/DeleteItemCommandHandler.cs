using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.Item.Handlers
{
    public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
    {
        private readonly IGenericRepository<ItemEntity> _repository;

        public DeleteItemCommandHandler(IGenericRepository<ItemEntity> repository) 
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteItemCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            await Task.Run(() => _repository.Delete(command.ItemId));
            _repository.Save();
            return Result.Ok();
        }
    }
}
