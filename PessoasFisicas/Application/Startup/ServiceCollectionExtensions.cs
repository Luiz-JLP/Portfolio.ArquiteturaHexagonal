using Application.Services;
using Domain.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddDependencyInjection();
            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            return services;
        }
    }
}
