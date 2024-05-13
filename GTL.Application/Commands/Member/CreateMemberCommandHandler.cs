using GTL.Domain.Common;

namespace GTL.Application.Commands.Member
{
    public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
    {
        public CreateMemberCommandHandler() 
        {
            
        }

        public Task<Result> Handle(CreateMemberCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
