using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEOTracker.Application.Interfaces;
using SEOTracker.Infrastructure.Data;
using SEOTracker.Infrastructure.Services;

namespace SEOTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SEOTrackerDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISEOTrackerDbContext, SEOTrackerDbContext>();

            services.AddSingleton<ISeleninumService, SeleniumService>();

            return services;
        }
    }
}
