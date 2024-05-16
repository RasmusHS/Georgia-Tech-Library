using AutoMapper;
using MediatR;
using GTL.Application.DTO.Item.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.Item.Handlers
{
    public class GetItemQueryHandler : IQueryHandler<GetItemQuery, QueryItemDto>
    {
        private readonly IMapper _mapper;

        public GetItemQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryItemDto>> Handle(GetItemQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
