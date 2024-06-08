using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemBorrowings.Handlers
{
    public class UpdateBorrowingCommandHandler : ICommandHandler<UpdateBorrowingCommand>
    {
        private readonly IGenericRepository<ItemBorrowingsEntity> _repository;

        public UpdateBorrowingCommandHandler(IGenericRepository<ItemBorrowingsEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateBorrowingCommand command, CancellationToken cancellationToken = default)
        {
            object[] id = { command.MemberId, command.ItemId, command.StartDate };
            var model = await _repository.GetByIdAsync(id);

            model.Edit(
                command.MemberId,
                command.ItemId,
                command.StartDate,
                command.Due,
                command.ReturnedDate,
                command.RowVersion
                );

            var borrowing = await _repository.UpdateAsync(model);
            _repository.Save();
            return Result.Ok(borrowing);
        }
    }
}
