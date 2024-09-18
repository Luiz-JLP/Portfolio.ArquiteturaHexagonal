using Domain.Entities;
using Domain.Request;
using Domain.Result;

namespace Domain.ServiceContracts
{
    public interface IEnderecoService
    {
        public Task<Result<Endereco, Error>> CriarAsync(EnderecoRequest request);
        
        public Task<Result<Endereco, Error>> BuscarAsync(Guid id);

        public Task<Result<List<Endereco>, Error>> BuscarAsync();

        public Task<Result<Endereco, Error>> AtualizarAsync(Endereco endereco);

        public Task<Result<int, Error>> ExcluirAsync(Guid id);
    }
}
