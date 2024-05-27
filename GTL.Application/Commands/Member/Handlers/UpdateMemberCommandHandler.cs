using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;

namespace GTL.Application.Commands.Member.Handlers
{
    public class UpdateMemberCommandHandler : ICommandHandler<UpdateMemberCommand>
    {
        private readonly IGenericRepository<MemberEntity> _repository;

        public UpdateMemberCommandHandler(IGenericRepository<MemberEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateMemberCommand command, CancellationToken cancellationToken = default)
        {
            // Read
            var model = await _repository.GetByIdAsync(command.MemberId);

            // Edit
            model.Edit(
                //command.MemberId, 
                command.Name,
                command.HomeAddress,
                command.CampusAddress,
                command.PhoneNumber,
                command.Email,
                command.Type,
                command.SSN,
                command.CardExpirationDate,
                command.EmployeePosition,
                command.RowVersion
                );

            // Save
            var member = await _repository.UpdateAsync(model);
            _repository.Save();
            return Result.Ok(member);
        }
    }
}
