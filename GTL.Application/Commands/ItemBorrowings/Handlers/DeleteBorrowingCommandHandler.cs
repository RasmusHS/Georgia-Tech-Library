using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.ItemBorrowings.Handlers
{
    public class DeleteBorrowingCommandHandler : ICommandHandler<DeleteBorrowingCommand>
    {
        private readonly IGenericRepository<ItemBorrowingsEntity> _repository;

        public DeleteBorrowingCommandHandler(IGenericRepository<ItemBorrowingsEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteBorrowingCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            object[] id = { command.MemberId, command.ItemId, command.StartDate };
            await Task.Run(() => _repository.Delete(id));
            _repository.Save();
            return Result.Ok();
        }
    }
}
