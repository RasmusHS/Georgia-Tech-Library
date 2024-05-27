using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Acquisitions.Handlers
{
    public class UpdateAcquisitionCommandHandler : ICommandHandler<UpdateAcquisitionCommand>
    {
        private readonly IGenericRepository<AcquisitionEntity> _repository;

        public UpdateAcquisitionCommandHandler(IGenericRepository<AcquisitionEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateAcquisitionCommand command, CancellationToken cancellationToken = default)
        {
            object[] id = { command.MemberId, command.ItemCatalogId, command.RequestDate };
            var model = await _repository.GetByIdAsync(id);

            model.Edit(
                command.MemberId,
                command.ItemCatalogId,
                command.RequestDate,
                command.Amount,
                command.RowVersion
                );

            var acquisition = await _repository.UpdateAsync(model);
            _repository.Save();
            return Result.Ok(acquisition);
        }
    }
}
