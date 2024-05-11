using AutoMapper;
using MediatR;
using GTL.Application.DTO.Member.Query;
using GTL.Domain.Common;

namespace GTL.Application.Queries.Member.Handlers
{
    public class GetMemberQueryHandler : IQueryHandler<GetMemberQuery, QueryMemberDto>
    {
        private readonly IMapper _mapper;

        public GetMemberQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Result<QueryMemberDto>> Handle(GetMemberQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
