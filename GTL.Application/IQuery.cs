using GTL.Domain.Common;
using MediatR;

namespace GTL.Application
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
    }
}
