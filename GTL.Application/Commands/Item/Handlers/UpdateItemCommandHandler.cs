using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Item.Handlers
{
    public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand>
    {
        private readonly IGenericRepository<ItemEntity> _repository;

        public UpdateItemCommandHandler(IGenericRepository<ItemEntity> repository) 
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateItemCommand command, CancellationToken cancellationToken = default)
        {
            var model = await _repository.GetByIdAsync(command.ItemId);

            model.Edit(
                command.ItemCatalogId,
                command.IsLendable,
                command.DateCreated,
                command.Condition,
                command.RowVersion
                );

            var item = await _repository.UpdateAsync(model);
            _repository.Save();
            return Result.Ok(item);
        }
    }
}
