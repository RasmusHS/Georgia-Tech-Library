using GTL.Domain.Common;
using MediatR;

namespace GTL.Application
{
    public interface IQueryHandler<TQuery, TResult>
        : IRequestHandler<TQuery, Result<TResult>> where TQuery : IQuery<TResult>
    {
        new Task<Result<TResult>> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
