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
            return await repository.AtualizarAsync(pessoaFisica);
        }

        public async Task<Result<PessoaFisicaResponse, Error>> BuscarAsync(Guid id)
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

        public async Task<Result<List<PessoaFisicaResponse>, Error>> BuscarAsync()
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

        public async Task<Result<PessoaFisica, Error>> CriarAsync(PessoaFisica pessoaFisica)
        {
            var result = await repository.CriarAsync(pessoaFisica);
            emailService.EnviarEmail(new());

            return result;
        }

        public async Task<Result<int, Error>> ExcluirAsync(Guid id)
        {
            return await repository.ExcluirAsync(id);
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
