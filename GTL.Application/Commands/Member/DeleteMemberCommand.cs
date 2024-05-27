using EnsureThat;

namespace GTL.Application.Commands.Member
{
    public class DeleteMemberCommand : ICommand
    {
        public DeleteMemberCommand(Guid memberId) 
        {
            Ensure.That(memberId).IsNotEmpty();
            MemberId = memberId;
        }

        public Guid MemberId { get; set; }
    }
}
