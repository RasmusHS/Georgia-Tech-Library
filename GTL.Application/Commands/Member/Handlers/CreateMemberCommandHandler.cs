using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Member.Handlers
{
    public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
    {
        private readonly IGenericRepository<MemberEntity> _repository;

        public CreateMemberCommandHandler(IGenericRepository<MemberEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateMemberCommand command, CancellationToken cancellationToken = default)
        {
            Result<MemberEntity> memberResult = MemberEntity.Create
                (
                command.Name,
                command.HomeAddress,
                command.CampusAddress,
                command.PhoneNumber,
                command.Email,
                command.Type,
                command.SSN,
                command.EmployeePosition
                );
            if (memberResult.Failure) return memberResult;

            var member = await _repository.InsertAsync(memberResult);
            _repository.Save();
            return Result.Ok(member);

        }
    }
}
