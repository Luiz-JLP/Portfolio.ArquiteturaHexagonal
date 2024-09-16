using Application.Errors;
using Domain.Entities;
using Domain.Ports;
using Domain.Response;
using Domain.Result;
using Domain.ServiceContracts;

namespace Application.Services
{
    public class PessoaFisicaService(
        IPessoaFisicaRepository repository,
        IEnderecoService enderecoService,
        IEmailService emailService
        ) : IPessoaFisicaService
    {
        public async Task<Result<PessoaFisica, Error>> AtualizarAsync(PessoaFisica pessoaFisica)
        {
            try
            {
                return await repository.AtualizarAsync(pessoaFisica);
            }
            catch (Exception ex)
            {
                return PessoaFisicaErrors.Atualizar($"Houve um erro durante o processo de atualização. Mensagem: {ex.Message}");
            }
        }

        public async Task<Result<PessoaFisicaResponse, Error>> BuscarAsync(Guid id)
        {
            try
            {
                var pessoa = await repository.BuscarAsync(id);
                var enderecoTask = enderecoService.BuscarAsync(pessoa.Endereco);

                var response = ConvertToResponse(pessoa);

                var enderecoResult = await enderecoTask;

                enderecoResult.Match(
                    value => response.Endereco = value,
                    error => error
                    );

                return response;
            }
            catch (Exception ex)
            {
                return PessoaFisicaErrors.Buscar($"Houve um erro durante o processo de busca. Mensagem: {ex.Message}");
            }            
        }

        public async Task<Result<List<PessoaFisicaResponse>, Error>> BuscarAsync()
        {
            try
            {
                List<PessoaFisicaResponse> pessoasResponse = [];
                var pessoas = await repository.BuscarAsync();

                foreach (var pessoa in pessoas)
                {
                    var enderecoTask = enderecoService.BuscarAsync(pessoa.Endereco);
                    var response = ConvertToResponse(pessoa);

                    var enderecoResult = await enderecoTask;

                    enderecoResult.Match(
                        value => response.Endereco = value,
                        error => error
                        );

                    pessoasResponse.Add(response);
                }

                return pessoasResponse;
            }
            catch (Exception ex)
            {
                return PessoaFisicaErrors.Buscar($"Houve um erro durante o processo de busca. Mensagem: {ex.Message}");
            }            
        }

        public async Task<Result<PessoaFisica, Error>> CriarAsync(PessoaFisica pessoaFisica)
        {
            try
            {
                var result = await repository.CriarAsync(pessoaFisica);
                emailService.EnviarEmail(new());

                return result;
            }
            catch (Exception ex)
            {
                return PessoaFisicaErrors.Criar($"Houve um erro durante o processo de criação. Mensagem: {ex.Message}");
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
                return PessoaFisicaErrors.Excluir($"Houve um erro durante o processo de exclusão. Mensagem: {ex.Message}");
            }
        }

        private static PessoaFisicaResponse ConvertToResponse(PessoaFisica pessoaFisica)
        {
            return new()
            {
                Id = pessoaFisica.Id,
                Nome = pessoaFisica.Nome,
                Sobrenome = pessoaFisica.Sobrenome,
                Nascimento = pessoaFisica.Nascimento
            };
        }
    }
}
