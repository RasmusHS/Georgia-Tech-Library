using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ReserveItem.Handlers
{
    public class UpdateReservationCommandHandler : ICommandHandler<UpdateReservationCommand>
    {
        private readonly IGenericRepository<ReserveItemEntity> _repository;

        public UpdateReservationCommandHandler(IGenericRepository<ReserveItemEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateReservationCommand command, CancellationToken cancellationToken = default)
        {
            object[] id = { command.MemberId, command.ItemCatalogId };
            var model = await _repository.GetByIdAsync(id);

            model.Edit(
                command.MemberId,
                command.ItemCatalogId,
                command.DateReserved,
                command.Amount,
                command.RowVersion
                );

            var reservation = await _repository.UpdateAsync(model);
            _repository.Save();
            return Result.Ok(reservation);
        }
    }
}
