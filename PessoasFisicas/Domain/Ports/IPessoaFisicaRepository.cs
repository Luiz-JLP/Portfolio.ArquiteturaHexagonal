using Domain.Entities;

namespace Domain.Ports
{
    public interface IPessoaFisicaRepository
    {
        public Task<PessoaFisica> CriarAsync(PessoaFisica pessoaFisica);

        public Task<PessoaFisica> BuscarAsync(Guid id);

        public Task<IEnumerable<PessoaFisica>> BuscarAsync();

        public Task<PessoaFisica> AtualizarAsync(PessoaFisica pessoaFisica);

        public Task<int> ExcluirAsync(Guid id);
    }
}
