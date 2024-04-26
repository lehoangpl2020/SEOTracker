using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SEOTracker.Application.Behaviours;
using SEOTracker.Application.History.Queries;
using SEOTracker.Application.Trackers.Commands;

namespace SEOTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            //services.AddMediatR(cfg => cfg.AsScoped(), assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetRankRecordQueryHandler).Assembly));
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBahavior<,>));

            services.AddValidatorsFromAssemblyContaining<SearchCommandValidator>(ServiceLifetime.Scoped);

            return services;
        }
    }
}
