using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemCatalog
{
    public class CreateCatalogEntryWithAuthorsCommandHandler : ICommandHandler<CreateCatalogEntryWithAuthorsCommand>
    {
        private readonly IGenericRepository<ItemCatalogEntity> _catalogRepository;
        private readonly IGenericRepository<AuthorEntity> _authorRepository;

        public CreateCatalogEntryWithAuthorsCommandHandler(IGenericRepository<ItemCatalogEntity> catalogRepository, IGenericRepository<AuthorEntity> authorRepository)
        {
            _catalogRepository = catalogRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Result> Handle(CreateCatalogEntryWithAuthorsCommand command, CancellationToken cancellationToken = default)
        {
            Result<ItemCatalogEntity> catalogResult = ItemCatalogEntity.Create
                (
                command.ISBN,
                command.Title,
                command.Description,
                command.SubjectArea,
                command.Type,
                command.Edition
                );
            if (catalogResult.Failure) return catalogResult;
            var catalog = await _catalogRepository.InsertAsync(catalogResult);
            _catalogRepository.Save();
            foreach (var author in command.Authors)
            {
                Result<AuthorEntity> authorResult = AuthorEntity.Create
                    (
                    author.ItemCatalogId = catalogResult.Value.ItemCatalogId,
                    author.Name
                    );
                if (authorResult.Failure) return authorResult;
                var authorEntity = await _authorRepository.InsertAsync(authorResult);
                _authorRepository.Save();
                catalog.Authors.Add(authorEntity);
            }
            return Result.Ok(catalog);
        }
    }
}
