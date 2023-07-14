using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Infrastructure.Persistence;
using StudentGrades.Infrastructure.Persistence.Interceptors;
using StudentGrades.Infrastructure.Services;

namespace StudentGrades.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureService
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString: configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IGuidGenerator, GuidGeneratorService>();

            return services;
        }
    }
}
