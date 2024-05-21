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
            var authorsModel = await _authorRepository.GetAllAsync(x => x.ItemCatalogId == command.ItemCatalogId);

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

            if ((authorsModel == null || authorsModel.Count() == 0) && (command.Authors == null || command.Authors.Count() == 0))
            {
                // Update only the item
                _catalogRepository.Save();
                return Result.Ok(catalog);
            }
            else if ((authorsModel == null || authorsModel.Count() == 0) && (command.Authors != null || command.Authors.Count() != 0))
            {
                // Update an items list of authors when said item has no authors
                foreach (var author in command.Authors)
                {
                    var authorModel = AuthorEntity.Create(author.ItemCatalogId, author.Name);
                    var authors = await _authorRepository.InsertAsync(authorModel);
                }

                _catalogRepository.Save();
                _authorRepository.Save();
                return Result.Ok(catalog);
            }
            else if ((authorsModel != null || authorsModel.Count() != 0) && (command.Authors == null || command.Authors.Count() == 0))
            {
                // Update an item with no addditional authors
                foreach (var author in authorsModel)
                {
                    author.Edit(
                        command.ItemCatalogId,
                        author.Name,
                        command.RowVersion
                        );
                    var authors = await _authorRepository.UpdateAsync(author);
                }
                _catalogRepository.Save();
                return Result.Ok(catalog);
            }
            else
            {
                // Update an item with additional authors
                foreach (var author in authorsModel)
                {
                    author.Edit(
                        command.ItemCatalogId,
                        author.Name,
                        author.RowVersion
                        );
                    var authors = await _authorRepository.UpdateAsync(author);
                }

                foreach (var author in command.Authors)
                {
                    var authorModel = AuthorEntity.Create(author.ItemCatalogId, author.Name);
                    var authors = await _authorRepository.InsertAsync(authorModel);
                }

                _catalogRepository.Save();
                _authorRepository.Save();
                return Result.Ok(catalog);
            }

            //foreach (var author in authorsModel)
            //{
            //    author.Edit(
            //        command.ItemCatalogId,
            //        author.Name,
            //        command.RowVersion
            //        );
            //    var authors = await _authorRepository.UpdateAsync(author);
            //}

            //foreach (var author in command.Authors)
            //{
            //    var authorModel = AuthorEntity.Create(author.ItemCatalogId, author.Name).Value;
            //    var authors = await _authorRepository.InsertAsync(authorModel);
            //}

            //_catalogRepository.Save();
            //_authorRepository.Save();

            //return Result.Ok(catalog);
        }
    }
}
