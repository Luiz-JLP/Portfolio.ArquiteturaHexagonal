using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class EnderecoRepository(InMemoryContext context) : IEnderecoRepository
    {
        public async Task<Endereco> AtualizarAsync(Endereco endereco)
        {
            context.Enderecos.Update(endereco);
            await context.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> BuscarAsync(Guid id)
        {
            return await context.Enderecos.FirstOrDefaultAsync(p => p.Id == id) ?? new();
        }

        public async Task<IEnumerable<Endereco>> BuscarAsync()
        {
            return await context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> CriarAsync(Endereco endereco)
        {
            context.Enderecos.Add(endereco);
            await context.SaveChangesAsync();
            return endereco;
        }

        public async Task<int> ExcluirAsync(Guid id)
        {
            var endereco = await context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);

            if (endereco is null)
                return 0;

            context.Remove(endereco);
            return await context.SaveChangesAsync();
        }
    }
}
