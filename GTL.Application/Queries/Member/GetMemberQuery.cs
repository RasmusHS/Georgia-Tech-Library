using GTL.Application.DTO.Member.Query;
using EnsureThat;

namespace GTL.Application.Queries.Member
{
    public class GetMemberQuery : IQuery<QueryMemberDto>
    {
        public GetMemberQuery(Guid memberId) 
        {
            Ensure.That(memberId, nameof(memberId)).IsNotEmpty();
            MemberId = memberId;
        }

        public Guid MemberId { get; private set; }
    }
}
