using Domain.Entities;
using Domain.Response;
using Domain.Result;

namespace Domain.ServiceContracts
{
    public interface IPessoaFisicaService
    {
        public Task<Result<PessoaFisica, Error>> CriarAsync(PessoaFisica pessoaFisica);

        public Task<Result<PessoaFisicaResponse, Error>> BuscarAsync(Guid id);

        public Task<Result<List<PessoaFisicaResponse>, Error>> BuscarAsync();

        public Task<Result<PessoaFisica, Error>> AtualizarAsync(PessoaFisica pessoaFisica);

        public Task<Result<int, Error>> ExcluirAsync(Guid id);
    }
}
