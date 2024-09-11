using Domain.Ports;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataInfrastructure(this IServiceCollection services)
        {
            services.AddDataBaseContext();
            services.AddDependencyInjection();
            return services;
        }

        private static IServiceCollection AddDataBaseContext(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("Hexagonal"));
            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            return services;
        }
    }
}
