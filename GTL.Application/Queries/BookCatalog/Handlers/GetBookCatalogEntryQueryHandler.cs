using AutoMapper;
using MediatR;
using GTL.Application.DTO.BookCatalog.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.BookCatalog.Handlers
{
    public class GetBookCatalogEntryQueryHandler : IQueryHandler<GetBookCatalogEntryQuery, QueryBookCatalogDto>
    {
        private readonly IMapper _mapper;

        public GetBookCatalogEntryQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryBookCatalogDto>> Handle(GetBookCatalogEntryQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
