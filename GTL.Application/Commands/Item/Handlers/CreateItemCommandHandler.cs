using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Item.Handlers
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private readonly IGenericRepository<ItemEntity> _repository;

        public CreateItemCommandHandler(IGenericRepository<ItemEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateItemCommand command, CancellationToken cancellationToken = default)
        {
            Result<ItemEntity> itemResult = ItemEntity.Create
                (
                command.ItemCatalogId,
                command.IsLendable,
                command.DateCreated,
                command.Condition
                );
            if (itemResult.Failure) return itemResult;

            var item = await _repository.InsertAsync(itemResult);
            _repository.Save();
            return Result.Ok(item);
        }
    }
}
