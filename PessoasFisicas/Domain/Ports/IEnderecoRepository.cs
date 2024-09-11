using Domain.Entities;

namespace Domain.Ports
{
    public interface IEnderecoRepository
    {
        public Task<Endereco> CriarAsync(Endereco endereco);

        public Task<Endereco> BuscarAsync(Guid id);

        public Task<IEnumerable<Endereco>> BuscarAsync();

        public Task<Endereco> AtualizarAsync(Endereco endereco);

        public Task<int> ExcluirAsync(Guid id);
    }
}
