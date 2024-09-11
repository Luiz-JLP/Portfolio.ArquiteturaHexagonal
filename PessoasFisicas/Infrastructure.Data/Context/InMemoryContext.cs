using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class InMemoryContext(DbContextOptions<InMemoryContext> options) : DbContext(options)
    {
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}
