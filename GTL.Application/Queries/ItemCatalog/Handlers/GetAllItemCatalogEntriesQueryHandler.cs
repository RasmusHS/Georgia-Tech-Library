using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.ItemCatalog.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.ItemCatalog.Handlers
{
    public class GetAllItemCatalogEntriesQueryHandler : IQueryHandler<GetAllCatalogEntriesQuery, CollectionResponseBase<QueryItemCatalogDto>>
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

        public Task<Result<CollectionResponseBase<QueryItemCatalogDto>>> Handle(GetAllCatalogEntriesQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
