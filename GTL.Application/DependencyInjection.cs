using GTL.Application.Commands.Member;
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
            //services.AddScoped<IDispatcher, Dispatcher>();

            services.AddScoped<IDispatcher>(sp => new Dispatcher(sp.GetService<IMediator>()));
            //services.AddScoped(typeof(ICommand), typeof(ICommandHandler<>));
            //services.AddScoped(typeof(IQuery<>), typeof(IQueryHandler<,>));

            //services.AddScoped<, >();
            // Book
            //services.AddScoped(typeof(ICommand), typeof(CreateMemberCommand));
            services.AddScoped(typeof(ICommandHandler<CreateMemberCommand>), typeof(CreateMemberCommandHandler));
            //services.AddScoped(typeof(IQuery<QueryMemberDto>), typeof(GetMemberQuery));
            services.AddScoped(typeof(IQueryHandler<GetMemberQuery, QueryMemberDto>), typeof(GetMemberQueryHandler));
            //services.AddScoped<,>();

            // BookBorrowings
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();

            // BookCatalog
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();

            // Member
            //services.AddScoped<, >();
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();
            //services.AddScoped<,>();

            return services;
        }
    }
}
