using GTL.Application.Data;
using GTL.Domain.Common;
using GTL.Domain.Models;
using EnsureThat;

namespace GTL.Application.Commands.Member
{
    public class DeleteMemberCommandHandler : ICommandHandler<DeleteMemberCommand>
    {
        private readonly IGenericRepository<MemberEntity> _repository;

        public DeleteMemberCommandHandler(IGenericRepository<MemberEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteMemberCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            await Task.Run(() => _repository.Delete(command.MemberId));
            _repository.Save();
            return Result.Ok();
        }
    }
}
