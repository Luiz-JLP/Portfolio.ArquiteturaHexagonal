using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class PessoaFisicaRepository(InMemoryContext context) : IPessoaFisicaRepository
    {
        public async Task<PessoaFisica> AtualizarAsync(PessoaFisica pessoaFisica)
        {
            context.PessoaFisicas.Update(pessoaFisica);
            await context.SaveChangesAsync();
            return pessoaFisica;
        }

        public async Task<PessoaFisica> BuscarAsync(Guid id)
        {
            return await context.PessoaFisicas.FirstOrDefaultAsync(p => p.Id == id) ?? new();
        }

        public async Task<IEnumerable<PessoaFisica>> BuscarAsync()
        {
            return await context.PessoaFisicas.ToListAsync();
        }

        public async Task<PessoaFisica> CriarAsync(PessoaFisica pessoaFisica)
        {
            context.PessoaFisicas.Add(pessoaFisica);
            await context.SaveChangesAsync();
            return pessoaFisica;
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            var pessoaFisica = context.PessoaFisicas.FirstOrDefaultAsync(x => x.Id == id);

            if (pessoaFisica is null)
                return 0;

            context.Remove(pessoaFisica);
            return await context.SaveChangesAsync();
        }
    }
}
