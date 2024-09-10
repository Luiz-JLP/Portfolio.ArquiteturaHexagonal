using Domain.Entities;

namespace Domain.ServiceContracts
{
    public interface IEnderecoService
    {
        public Task<Endereco> CriarAsync(Endereco endereco);
        
        public Task<Endereco> BuscarAsync(Guid Id);

        public Task<IEnumerable<Endereco>> BuscarAsync();

        public Task<Endereco> AtualizarAsync(Endereco endereco);

        public Task<int> ExcluirAsync(Guid Id);
    }
}
