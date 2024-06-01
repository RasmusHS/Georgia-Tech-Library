using GTL.Application.Commands.ItemCatalog.WithAcquisitions;
using GTL.Application.Commands.ItemCatalog.WithItems;
using GTL.Application.Commands.Member;
using GTL.Application.Commands.Member.Handlers;
using GTL.Application.DTO.Member.Query;
using GTL.Application.Queries.Member;
using GTL.Application.Queries.Member.Handlers;
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

            // Member
            services.AddScoped(typeof(ICommandHandler<CreateMemberCommand>), typeof(CreateMemberCommandHandler));
            services.AddScoped(typeof(IQueryHandler<GetMemberQuery, QueryMemberDto>), typeof(GetMemberQueryHandler));
            services.AddScoped(typeof(ICommandHandler<UpdateMemberCommand>), typeof(UpdateMemberCommandHandler));
            services.AddScoped(typeof(ICommandHandler<DeleteMemberCommand>), typeof(DeleteMemberCommandHandler));

            return services;
        }
    }
}
