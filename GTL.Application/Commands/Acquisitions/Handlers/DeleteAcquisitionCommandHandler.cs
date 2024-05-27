using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.Acquisitions.Handlers
{
    public class DeleteAcquisitionCommandHandler : ICommandHandler<DeleteAcquisitionCommand>
    {
        private readonly IGenericRepository<AcquisitionEntity> _repository;

        public DeleteAcquisitionCommandHandler(IGenericRepository<AcquisitionEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteAcquisitionCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            object[] id = { command.MemberId, command.ItemCatalogId, command.RequestDate };
            await Task.Run(() => _repository.Delete(id));
            _repository.Save();
            return Result.Ok();
        }
    }
}
