using GTL.Domain.Common;
using MediatR;

namespace GTL.Application
{
    public interface ICommandHandler<TCommand> 
        : IRequestHandler<TCommand, Result> where TCommand : ICommand
    {
        new Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
