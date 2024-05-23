using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemCatalog
{
    public class UpdateCatalogEntryCommandHandler : ICommandHandler<UpdateCatalogEntryCommand>
    {
        private readonly IGenericRepository<ItemCatalogEntity> _catalogRepository;
        private readonly IGenericRepository<AuthorEntity> _authorRepository;

        public UpdateCatalogEntryCommandHandler(IGenericRepository<ItemCatalogEntity> catalogRepository, IGenericRepository<AuthorEntity> authorRepository)
        {
            _catalogRepository = catalogRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Result> Handle(UpdateCatalogEntryCommand command, CancellationToken cancellationToken = default)
        {
            var catalogModel = await _catalogRepository.GetByIdAsync(command.ItemCatalogId);

            catalogModel.Edit(
                command.ISBN,
                command.Title,
                command.Description,
                command.SubjectArea,
                command.Type,
                command.Edition,
                command.RowVersion
                );

            var catalog = await _catalogRepository.UpdateAsync(catalogModel);
            _catalogRepository.Save();

            return Result.Ok(catalog);
        }
    }
}
