using Domain.Entities;
using Domain.Request;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController(IEnderecoService service) : Controller
    {
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(Endereco), StatusCodes.Status200OK)]
        public async Task<IActionResult> Buscar(Guid id)
        {
            var enderecoResult = await service.BuscarAsync(id);

            ObjectResult? result = null;

            enderecoResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Endereco>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Buscar()
        {
            var enderecoResult = await service.BuscarAsync();

            ObjectResult? result = null;

            enderecoResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Endereco), StatusCodes.Status200OK)]
        public async Task<IActionResult> Criar(EnderecoRequest request)
        {
            var enderecoResult = await service.CriarAsync(request);

            ObjectResult? result = null;

            enderecoResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpPut]
        [ProducesResponseType(typeof(Endereco), StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar(Endereco enderecoAtualizado)
        {
            var enderecoResult = await service.AtualizarAsync(enderecoAtualizado);

            ObjectResult? result = null;

            enderecoResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var enderecoResult = await service.ExcluirAsync(id);

            ObjectResult? result = null;

            enderecoResult.Match(
                value => result = Ok(value),
                error => result = BadRequest(error.ToJson())
            );

            return result!;
        }
    }
}
