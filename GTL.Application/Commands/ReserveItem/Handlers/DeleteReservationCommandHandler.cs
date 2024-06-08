using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.ReserveItem.Handlers
{
    public class DeleteReservationCommandHandler : ICommandHandler<DeleteReservationCommand>
    {
        private readonly IGenericRepository<ReserveItemEntity> _repository;

        public DeleteReservationCommandHandler(IGenericRepository<ReserveItemEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteReservationCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            object[] id = { command.MemberId, command.ItemCatalogId };
            await Task.Run(() => _repository.Delete(id));
            _repository.Save();
            return Result.Ok();
        }
    }
}
