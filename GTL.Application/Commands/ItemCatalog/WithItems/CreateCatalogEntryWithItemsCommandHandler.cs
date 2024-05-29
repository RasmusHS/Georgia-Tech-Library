using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemCatalog.WithItems
{
    public class CreateCatalogEntryWithItemsCommandHandler : ICommandHandler<CreateCatalogEntryWithItemsCommand>
    {
        private readonly IGenericRepository<ItemCatalogEntity> _catalogRepository;
        private readonly IGenericRepository<AuthorEntity> _authorRepository;
        private readonly IGenericRepository<ItemEntity> _itemRepository;

        public CreateCatalogEntryWithItemsCommandHandler(IGenericRepository<ItemCatalogEntity> catalogRepository, IGenericRepository<AuthorEntity> authorRepository, IGenericRepository<ItemEntity> itemRepository)
        {
            _catalogRepository = catalogRepository;
            _authorRepository = authorRepository;
            _itemRepository = itemRepository;
        }

        public async Task<Result> Handle(CreateCatalogEntryWithItemsCommand command, CancellationToken cancellationToken = default)
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

            List<AuthorEntity> authors = new List<AuthorEntity>();
            foreach (var author in command.Authors)
            {
                Result<AuthorEntity> authorResult = AuthorEntity.Create
                    (
                    author.ItemCatalogId = catalogResult.Value.ItemCatalogId,
                    author.Name
                    );
                if (authorResult.Failure) return authorResult;
                authors.Add(authorResult);
            }

            List<ItemEntity> items = new List<ItemEntity>();
            foreach (var item in command.Items)
            {
                Result<ItemEntity> itemResult = ItemEntity.Create
                    (
                    item.ItemCatalogId = catalogResult.Value.ItemCatalogId,
                    item.IsLendable,
                    item.DateCreated,
                    item.Condition
                    );
                if (itemResult.Failure) return itemResult;
                items.Add(itemResult);
            }

            await _authorRepository.InsertRangeAsync(authors);
            await _itemRepository.InsertRangeAsync(items);
            catalog.Authors.AddRange(authors);
            catalog.Items.AddRange(items);
            _catalogRepository.Save();
            _authorRepository.Save();
            _itemRepository.Save();
            return Result.Ok(catalog);
        }
    }
}
