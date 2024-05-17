using AutoMapper;
using GTL.Application.DTO.Member.Query;
using GTL.Domain.Common;
using GTL.Application.Data;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Member.Handlers
{
    public class GetMemberQueryHandler : IQueryHandler<GetMemberQuery, QueryMemberDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<MemberEntity> _repository;

        public GetMemberQueryHandler(IGenericRepository<MemberEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<QueryMemberDto>> Handle(GetMemberQuery query, CancellationToken cancellationToken = default)
        {
            var member = await _repository.GetByIdAsync(query.MemberId);
            var memberDto = _mapper.Map<QueryMemberDto>(member);
            return Result.Ok(memberDto);
        }
    }
}
