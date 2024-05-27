using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.Author.Handlers
{
    public class DeleteAuthorCommandHandler : ICommandHandler<DeleteAuthorCommand>
    {
        private readonly IGenericRepository<AuthorEntity> _repository;

        public DeleteAuthorCommandHandler(IGenericRepository<AuthorEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            object[] id = { command.ItemCatalogId, command.Name };
            await Task.Run(() => _repository.Delete(id));
            _repository.Save();
            return Result.Ok();
        }
    }
}
