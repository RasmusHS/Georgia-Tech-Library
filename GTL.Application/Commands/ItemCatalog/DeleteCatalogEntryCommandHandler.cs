using EnsureThat;
using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemCatalog
{
    public class DeleteCatalogEntryCommandHandler : ICommandHandler<DeleteCatalogEntryCommand>
    {
        private readonly IGenericRepository<ItemCatalogEntity> _catalogrepository;
        //private readonly IGenericRepository<AuthorEntity> _authorRepository;

        public DeleteCatalogEntryCommandHandler(IGenericRepository<ItemCatalogEntity> catalogRepository/*, IGenericRepository<AuthorEntity> authorRepository*/)
        {
            _catalogrepository = catalogRepository;
            //_authorRepository = authorRepository;
        }

        public async Task<Result> Handle(DeleteCatalogEntryCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            await Task.Run(() => _catalogrepository.Delete(command.ItemCatalogId));
            _catalogrepository.Save();
            return Result.Ok();
        }
    }
}
