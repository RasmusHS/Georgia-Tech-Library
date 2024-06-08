using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ReserveItem.Handlers
{
    public class CreateReservationCommandHandler : ICommandHandler<CreateReservationCommand>
    {
        private readonly IGenericRepository<ReserveItemEntity> _repository;

        public CreateReservationCommandHandler(IGenericRepository<ReserveItemEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateReservationCommand command, CancellationToken cancellationToken = default)
        {
            Result<ReserveItemEntity> reservationResult = ReserveItemEntity.Create
                (
                command.MemberId,
                command.ItemCatalogId,
                command.Amount
                );
            if (reservationResult.Failure) return reservationResult;

            var reservation = await _repository.InsertAsync(reservationResult);
            _repository.Save();
            return Result.Ok(reservation);
        }
    }
}
