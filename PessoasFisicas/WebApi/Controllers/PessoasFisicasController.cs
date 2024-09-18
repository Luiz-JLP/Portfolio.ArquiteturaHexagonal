using Domain.Entities;
using Domain.Request;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController(IPessoaFisicaService service) : Controller
    {
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        public async Task<IActionResult> Buscar(Guid id)
        {
            var pessoaFisicaResult = await service.BuscarAsync(id);

            ObjectResult? result = null;

            pessoaFisicaResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PessoaFisica>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Buscar()
        {
            var pessoaFisicaResult = await service.BuscarAsync();

            ObjectResult? result = null;

            pessoaFisicaResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        public async Task<IActionResult> Criar(PessoaFisicaRequest request)
        {
            var pessoaFisicaResult = await service.CriarAsync(request);

            ObjectResult? result = null;

            pessoaFisicaResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpPut]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar(PessoaFisica pessoaFisicaAtualizado)
        {
            var pessoaFisicaResult = await service.AtualizarAsync(pessoaFisicaAtualizado);

            ObjectResult? result = null;

            pessoaFisicaResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var pessoaFisicaResult = await service.ExcluirAsync(id);

            ObjectResult? result = null;

            pessoaFisicaResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }
    }
}
