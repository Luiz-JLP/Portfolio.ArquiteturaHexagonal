using Domain.Entities;
using Domain.Ports;
using Domain.Response;
using Domain.ServiceContracts;

namespace Application.Services
{
    public class PessoaFisicaService(
        IPessoaFisicaRepository repository,
        IEnderecoService enderecoService,
        IEmailService emailService
        ) : IPessoaFisicaService
    {
        public async Task<PessoaFisica> AtualizarAsync(PessoaFisica PessoaFisica)
        {
            return await repository.AtualizarAsync(PessoaFisica);
        }

        public async Task<PessoaFisicaResponse> BuscarAsync(Guid Id)
        {
            var pessoa = await repository.BuscarAsync(Id);
            var enderecoTask = enderecoService.BuscarAsync(pessoa.Endereco);

            var response = ConvertToResponse(pessoa);
            response.Endereco = await enderecoTask;
            return response;
        }

        public async Task<IEnumerable<PessoaFisicaResponse>> BuscarAsync()
        {
            List<PessoaFisicaResponse> pessoasResponse = [];
            var pessoas = await repository.BuscarAsync();

            foreach (var pessoa in pessoas)
            {
                var enderecoTask = enderecoService.BuscarAsync(pessoa.Endereco);
                var response = ConvertToResponse(pessoa);
                response.Endereco = await enderecoTask;
                pessoasResponse.Add(response);
            }

            return pessoasResponse;
        }

        public async Task<PessoaFisica> CriarAsync(PessoaFisica PessoaFisica)
        {
            var result = await repository.CriarAsync(PessoaFisica);
            emailService.EnviarEmail(new());

            return result;
        }

        public async Task<int> ExcluirAsync(Guid Id)
        {
            return await repository.ExcluirAsync(Id);
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
