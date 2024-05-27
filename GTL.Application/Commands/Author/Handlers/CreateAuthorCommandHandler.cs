using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Author.Handlers
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand>
    {
        private readonly IGenericRepository<AuthorEntity> _repository;

        public CreateAuthorCommandHandler(IGenericRepository<AuthorEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateAuthorCommand command, CancellationToken cancellationToken = default)
        {
            Result<AuthorEntity> authorResult = AuthorEntity.Create
                (
                command.ItemCatalogId,
                command.Name
                );
            if (authorResult.Failure) return authorResult;

            var author = await _repository.InsertAsync(authorResult);
            _repository.Save();
            return Result.Ok(author);
        }
    }
}
