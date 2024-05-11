using GTL.Domain.Common;

namespace GTL.Application
{
    public interface IDispatcher
    {
        Task<Result<T>> Dispatch<T>(IQuery<T> query);
        Task<Result> Dispatch(ICommand command);
    }
}
