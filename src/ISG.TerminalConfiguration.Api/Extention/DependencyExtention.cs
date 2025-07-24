using ISG.TerminalConfiguration.Api.Mappers;
using ISG.TerminalConfiguration.Domain.Interfaces.Repositories;
using ISG.TerminalConfiguration.Domain.Interfaces.Services;
using ISG.TerminalConfiguration.Domain.Services;
using ISG.TerminalConfiguration.Infrastructure.Data;
using ISG.TerminalConfiguration.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ISG.TerminalConfiguration.Api.Extention
{
    public static class DependencyExtention
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var cstring = configuration.GetSection("ConnectionString:DefaultConnection").Value;
            services.AddDbContext<ConfigurationsDbContext>(options =>
               options.UseSqlServer(cstring));
            // Register the TerminalConfigurationService
            services.AddScoped<ITerminalConfigurationService, TerminalConfigurationService>();
            // Register the TerminalSecurityService
            services.AddScoped<ITerminalSecurityService, TerminalSecurityService>();
            services.AddScoped<IKioskService, KioskService>();

            services.AddTransient<ITerminalInfoRepository, TerminalInfoRepository>();
            services.AddTransient<IKioskRepository, KioskRepository>();
            return services;
        }
    }
}
