using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.ItemCatalog.WithAcquisitions
{
    public class CreateCatalogEntryWithAcquisitionsCommandHandler : ICommandHandler<CreateCatalogEntryWithAcquisitionsCommand>
    {
        private readonly IGenericRepository<ItemCatalogEntity> _catalogRepository;
        private readonly IGenericRepository<AuthorEntity> _authorRepository;
        private readonly IGenericRepository<AcquisitionEntity> _acquisitionRepository;

        public CreateCatalogEntryWithAcquisitionsCommandHandler(IGenericRepository<ItemCatalogEntity> catalogRepository, IGenericRepository<AuthorEntity> authorRepository, IGenericRepository<AcquisitionEntity> acquisitionRepository)
        {
            _catalogRepository = catalogRepository;
            _authorRepository = authorRepository;
            _acquisitionRepository = acquisitionRepository;
        }

        public async Task<Result> Handle(CreateCatalogEntryWithAcquisitionsCommand command, CancellationToken cancellationToken = default)
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

            List<AcquisitionEntity> acquisitions = new List<AcquisitionEntity>();
            foreach (var acquisition in command.Acquisitions)
            {
                Result<AcquisitionEntity> acquisitionResult = AcquisitionEntity.Create
                    (
                    acquisition.MemberId,
                    acquisition.ItemCatalogId = catalogResult.Value.ItemCatalogId,
                    acquisition.RequestDate,
                    acquisition.Amount
                    );
                if (acquisitionResult.Failure) return acquisitionResult;
                acquisitions.Add(acquisitionResult);
            }

            await _authorRepository.InsertRangeAsync(authors);
            await _acquisitionRepository.InsertRangeAsync(acquisitions);
            catalog.Authors.AddRange(authors);
            catalog.AcquisitionItems.AddRange(acquisitions);
            _catalogRepository.Save();
            _authorRepository.Save();
            _acquisitionRepository.Save();
            return Result.Ok(catalog);
        }
    }
}
