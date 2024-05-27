using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Acquisitions.Handlers
{
    public class CreateAcquisitionCommandHandler : ICommandHandler<CreateAcquisitionCommand>
    {
        private readonly IGenericRepository<AcquisitionEntity> _repository;

        public CreateAcquisitionCommandHandler(IGenericRepository<AcquisitionEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateAcquisitionCommand command, CancellationToken cancellationToken = default)
        {
            Result<AcquisitionEntity> acquisitionResult = AcquisitionEntity.Create
                (
                command.MemberId,
                command.ItemCatalogId,
                command.RequestDate,
                command.Amount
                );
            if (acquisitionResult.Failure) return acquisitionResult;

            var acquisition = await _repository.InsertAsync(acquisitionResult);
            _repository.Save();
            return Result.Ok(acquisition);
        }
    }
}
