using Application.Errors;
using Domain.Entities;
using Domain.Ports;
using Domain.Request;
using Domain.Result;
using Domain.ServiceContracts;

namespace Application.Services
{
    public class EnderecoService(IEnderecoRepository repository) : IEnderecoService
    {
        public async Task<Result<Endereco, Error>> AtualizarAsync(Endereco endereco)
        {
            try
            {
                return await repository.AtualizarAsync(endereco);
            }
            catch (Exception ex)
            {
                return EnderecoErrors.Atualizar($"Houve um erro durante o processo de atualização. Mensagem: {ex.Message}");
            }
        }

        public async Task<Result<Endereco, Error>> BuscarAsync(Guid id)
        {
            try
            {
                return await repository.BuscarAsync(id);
            }
            catch (Exception ex)
            {
                return EnderecoErrors.Buscar($"Houve um erro durante o processo de busca. Mensagem: {ex.Message}");
            }
        }

        public async Task<Result<List<Endereco>, Error>> BuscarAsync()
        {
            try
            {
                var resultado = await repository.BuscarAsync();
                return resultado.ToList();
            }
            catch (Exception ex)
            {
                return EnderecoErrors.Buscar($"Houve um erro durante o processo de busca. Mensagem: {ex.Message}");
            }
        }

        public async Task<Result<Endereco, Error>> CriarAsync(EnderecoRequest request)
        {
            try
            {
                var endereco = ConvertToEndereco(request);
                return await repository.CriarAsync(endereco);
            }
            catch (Exception ex)
            {
                return EnderecoErrors.Criar($"Houve um erro durante o processo de criação. Mensagem: {ex.Message}");
            }
        }

        public async Task<Result<int, Error>> ExcluirAsync(Guid id)
        {
            try
            {
                return await repository.ExcluirAsync(id);
            }
            catch (Exception ex)
            {
                return EnderecoErrors.Excluir($"Houve um erro durante o processo de exclusão. Mensagem: {ex.Message}");
            }
        }

        private static Endereco ConvertToEndereco(EnderecoRequest request)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                TipoEndereco = request.TipoEndereco,
                Logradouro = request.Logradouro,
                Numero = request.Numero,
                Bairro = request.Bairro,
                Municipio = request.Municipio,
                Estado = request.Estado,
                Pais = request.Pais,
                Cep = request.Cep
            };
        }
    }
}
