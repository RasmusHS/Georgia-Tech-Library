using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemBorrowings.Handlers
{
    public class CreateBorrowingCommandHandler : ICommandHandler<CreateBorrowingCommand>
    {
        private readonly IGenericRepository<ItemBorrowingsEntity> _repository;

        public CreateBorrowingCommandHandler(IGenericRepository<ItemBorrowingsEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateBorrowingCommand command, CancellationToken cancellationToken = default)
        {
            Result<ItemBorrowingsEntity> borrowingResult = ItemBorrowingsEntity.Create
                (
                command.MemberId,
                command.ItemId,
                command.StartDate,
                command.Due,
                command.ReturnedDate
                );
            if (borrowingResult.Failure) return borrowingResult;

            var borrowing = await _repository.InsertAsync(borrowingResult);
            _repository.Save();
            return Result.Ok(borrowing);
        }
    }
}
