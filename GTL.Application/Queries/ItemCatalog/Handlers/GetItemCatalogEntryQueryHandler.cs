using AutoMapper;
using MediatR;
using GTL.Application.DTO.ItemCatalog.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.ItemCatalog.Handlers
{
    public class GetItemCatalogEntryQueryHandler : IQueryHandler<GetItemCatalogEntryQuery, QueryItemCatalogDto>
    {
        private readonly IMapper _mapper;

        public GetItemCatalogEntryQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryItemCatalogDto>> Handle(GetItemCatalogEntryQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
