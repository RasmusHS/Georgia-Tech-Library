using GTL.Application.Data;
using GTL.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GTL.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
