using GTL.Domain.Common;
using MediatR;

namespace GTL.Application
{
    public interface ICommand : IRequest<Result>
    {
    }
}
