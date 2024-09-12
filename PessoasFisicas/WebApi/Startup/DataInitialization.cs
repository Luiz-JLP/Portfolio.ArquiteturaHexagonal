using Domain.Entities;
using Domain.Enumerators;
using Infrastructure.Data.Context;

namespace WebApi.Startup
{
    public static class DataInitialization
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<InMemoryContext>();

            if (context is not null)
            {
                context.Database.EnsureCreated();

                if (!context.Enderecos.Any())
                {
                    var id = Guid.NewGuid();

                    context.Enderecos.Add(
                        new Endereco()
                        {
                            Id = id,
                            TipoEndereco = TipoEndereco.Avenida,
                            Logradouro = "Paulista",
                            Numero = "1000",
                            Bairro = "Cerqueira Cézar",
                            Municipio = "São Paulo",
                            Estado = "São Paulo",
                            Pais = "Brasil",
                            Cep = "01234-567"
                        }
                    );

                    context.SaveChanges();

                    context.PessoaFisicas.Add(
                        new PessoaFisica()
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Mario",
                            Sobrenome = "Quintana",
                            Endereco = id,
                            Nascimento = new DateTime(1994, 6, 10)
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
