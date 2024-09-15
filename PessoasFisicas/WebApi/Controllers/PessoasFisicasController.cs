using Domain.Entities;
using Domain.Response;
using Domain.Result;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController(IPessoaFisicaService service) : Controller
    {
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Buscar(Guid id)
        {
            var pessoaFisicaResult = await service.BuscarAsync(id);

            PessoaFisicaResponse? response = null;
            Error? errorResponse = null;

            pessoaFisicaResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var pessoaFisicaResult = await service.BuscarAsync();

            List<PessoaFisicaResponse>? response = null;
            Error? errorResponse = null;

            pessoaFisicaResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PessoaFisica novoPessoaFisica)
        {
            var pessoaFisicaResult = await service.CriarAsync(novoPessoaFisica);

            PessoaFisica? response = null;
            Error? errorResponse = null;

            pessoaFisicaResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(PessoaFisica pessoaFisicaAtualizado)
        {
            var pessoaFisicaResult = await service.AtualizarAsync(pessoaFisicaAtualizado);

            PessoaFisica? response = null;
            Error? errorResponse = null;

            pessoaFisicaResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var pessoaFisicaResult = await service.ExcluirAsync(id);

            int? response = null;
            Error? errorResponse = null;

            pessoaFisicaResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok($"Quantidade de registros excluídos: {response}") : BadRequest(errorResponse?.ToJson());
        }
    }
}
