using AutoMapper;
using GTL.Application.Data;
using GTL.Application.DTO.Member.Query;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Queries.Member.Handlers
{
    public class GetAllMembersQueryHandler : IQueryHandler<GetAllMembersQuery, CollectionResponseBase<QueryMemberDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<MemberEntity> _repository;

        public GetAllMembersQueryHandler(IGenericRepository<MemberEntity> repository, IMapper mapper) 
        { 
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CollectionResponseBase<QueryMemberDto>>> Handle(GetAllMembersQuery query, CancellationToken cancellationToken = default)
        {
            List<QueryMemberDto> result = new List<QueryMemberDto>();
            var members = await _repository.GetAllAsync();
            foreach (var member in members) 
            {
                QueryMemberDto dto = new QueryMemberDto();
                dto.MemberId = member.MemberId;
                dto.Name = member.Name;
                dto.HomeAddress = member.HomeAddress;
                dto.CampusAddress = member.CampusAddress;
                dto.PhoneNumber = member.PhoneNumber;
                dto.Email = member.Email;
                dto.Type = member.Type;
                dto.SSN = member.SSN;
                dto.CardExpirationDate = member.CardExpirationDate;
                dto.EmployeePosition = member.EmployeePosition;
                dto.RowVersion = member.RowVersion;

                result.Add(dto);
            }
            return new CollectionResponseBase<QueryMemberDto>()
            {
                Data = result
            };
        }
    }
}
