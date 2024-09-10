using Domain.Entities;
using Domain.Response;

namespace Domain.ServiceContracts
{
    public interface IPessoaFisicaService
    {
        public Task<PessoaFisica> CriarAsync(PessoaFisica PessoaFisica);

        public Task<PessoaFisicaResponse> BuscarAsync(Guid Id);

        public Task<IEnumerable<PessoaFisicaResponse>> BuscarAsync();

        public Task<PessoaFisica> AtualizarAsync(PessoaFisica PessoaFisica);

        public Task<int> ExcluirAsync(Guid Id);
    }
}
