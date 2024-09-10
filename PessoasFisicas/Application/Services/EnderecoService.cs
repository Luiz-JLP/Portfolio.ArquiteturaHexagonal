using Domain.Entities;
using Domain.Ports;
using Domain.ServiceContracts;

namespace Application.Services
{
    public class EnderecoService(IEnderecoRepository repository) : IEnderecoService
    {
        public async Task<Endereco> AtualizarAsync(Endereco endereco)
        {
            return await repository.AtualizarAsync(endereco);
        }

        public async Task<Endereco> BuscarAsync(Guid Id)
        {
            return await repository.BuscarAsync(Id);
        }

        public async Task<IEnumerable<Endereco>> BuscarAsync()
        {
            return await repository.BuscarAsync();
        }

        public async Task<Endereco> CriarAsync(Endereco endereco)
        {
            return await repository.CriarAsync(endereco);
        }

        public async Task<int> ExcluirAsync(Guid Id)
        {
            return await repository.ExcluirAsync(Id);
        }
    }
}
