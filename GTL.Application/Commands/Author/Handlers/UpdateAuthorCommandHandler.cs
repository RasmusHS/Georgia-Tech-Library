using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.Author.Handlers
{
    public class UpdateAuthorCommandHandler : ICommandHandler<UpdateAuthorCommand>
    {
        private readonly IGenericRepository<AuthorEntity> _repository;

        public UpdateAuthorCommandHandler(IGenericRepository<AuthorEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            object[] id = { command.ItemCatalogId, command.CurrentName };
            await Task.Run(() => _repository.Delete(id));

            Result<AuthorEntity> authorResult = AuthorEntity.Create
                (
                command.ItemCatalogId,
                command.UpdatedName
                );
            if (authorResult.Failure) return authorResult;

            var author = await _repository.InsertAsync(authorResult);
            _repository.Save();
            return Result.Ok(author);
        }
    }
}
