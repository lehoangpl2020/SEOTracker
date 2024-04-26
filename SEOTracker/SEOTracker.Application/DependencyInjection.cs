using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SEOTracker.Application.History.Queries;

namespace SEOTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            //services.AddMediatR(cfg => cfg.AsScoped(), assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetRankRecordQueryHandler).Assembly));


            return services;
        }
    }
}
