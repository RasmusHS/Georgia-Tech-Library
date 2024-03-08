using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GTL.Application.Data
{
    public interface IApplicationDbContext
    {
        // DbSet goes here


        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
