using Domain.Ports;
using Infrastructure.Email.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Email.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureEmailInfrastructure(this IServiceCollection services)
        {
            services.AddDependencyInjection();
            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, FakeEmailService>();
            return services;
        }
    }
}
