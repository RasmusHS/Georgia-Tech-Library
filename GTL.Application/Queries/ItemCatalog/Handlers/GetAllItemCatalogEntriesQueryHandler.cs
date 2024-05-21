using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Author.Query;
using GTL.Application.DTO.ItemCatalog.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.ItemCatalog.Handlers
{
    public class GetAllItemCatalogEntriesQueryHandler : IQueryHandler<GetAllItemCatalogEntriesQuery, CollectionResponseBase<QueryItemCatalogDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ItemCatalogEntity> _catalogRepository;
        private readonly IGenericRepository<AuthorEntity> _authorRepository;

        public GetAllItemCatalogEntriesQueryHandler(IGenericRepository<ItemCatalogEntity> catalogRepository, IGenericRepository<AuthorEntity> authorRepository, IMapper mapper) 
        {
            _catalogRepository = catalogRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<QueryItemCatalogDto>>> Handle(GetAllItemCatalogEntriesQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryItemCatalogDto> result = new List<QueryItemCatalogDto>();
            var catalogEntries = await _catalogRepository.GetAllAsync();
            foreach (var catalogEntry in catalogEntries) 
            {
                QueryItemCatalogDto dto = new QueryItemCatalogDto();
                dto.ISBN = catalogEntry.ISBN;
                dto.Title = catalogEntry.Title;
                dto.Description = catalogEntry.Description;
                dto.SubjectArea = catalogEntry.SubjectArea;
                dto.Type = catalogEntry.Type;
                dto.Edition = catalogEntry.Edition;

                var authors = await _authorRepository.GetAllAsync();
                foreach (var author in authors)
                {
                    dto.Authors.Add(new QueryAuthorDto 
                    { 
                        ItemCatalogId = author.ItemCatalogId,
                        Name = author.Name
                    });
                }

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryItemCatalogDto>()
            {
                Data = result
            };
        }
    }
}
