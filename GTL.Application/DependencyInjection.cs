using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GTL.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IDispatcher>(sp => new Dispatcher(sp.GetService<IMediator>()));

            return services;
        }
    }
}
