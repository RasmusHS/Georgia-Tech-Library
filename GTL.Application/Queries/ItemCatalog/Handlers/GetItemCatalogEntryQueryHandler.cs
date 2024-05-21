using AutoMapper;
using GTL.Application.DTO.ItemCatalog.Query;
using GTL.Domain.Common;
using GTL.Application.Data;
using GTL.Domain.Models;
using GTL.Application.DTO.Author.Query;

namespace GTL.Application.Queries.ItemCatalog.Handlers
{
    public class GetItemCatalogEntryQueryHandler : IQueryHandler<GetItemCatalogEntryQuery, QueryItemCatalogDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ItemCatalogEntity> _catalogRepository;
        private readonly IGenericRepository<AuthorEntity> _authorRepository;

        public GetItemCatalogEntryQueryHandler(IGenericRepository<ItemCatalogEntity> catalogRepository, IGenericRepository<AuthorEntity> authorRepository, IMapper mapper)
        {
            _catalogRepository = catalogRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Result<QueryItemCatalogDto>> Handle(GetItemCatalogEntryQuery query, CancellationToken cancellationToken = default)
        {
            var catalog = await _catalogRepository.GetByIdAsync(query.ItemCatalogId);
            var authors = await _authorRepository.GetAllAsync(x => x.ItemCatalogId == query.ItemCatalogId);
            if (authors == null || authors.Count() == 0) 
            {
                var catalogDto = _mapper.Map<QueryItemCatalogDto>(catalog);
                return Result.Ok(catalogDto);
            }
            else
            {
                var catalogDto = _mapper.Map<QueryItemCatalogDto>(catalog);
                catalogDto.Authors = _mapper.Map<List<QueryAuthorDto>>(authors);
                return Result.Ok(catalogDto);
            }
            //var catalogDto = _mapper.Map<QueryItemCatalogDto>(catalog);
            //catalogDto.Authors = _mapper.Map<List<QueryAuthorDto>>(authors);
            //return Result.Ok(catalogDto);
        }
    }
}
