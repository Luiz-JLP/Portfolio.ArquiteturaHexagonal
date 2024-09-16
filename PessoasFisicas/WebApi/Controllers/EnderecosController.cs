using Domain.Entities;
using Domain.Result;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController(IEnderecoService service) : Controller
    {
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Buscar(Guid id)
        {
            var enderecoResult = await service.BuscarAsync(id);

            Endereco? response = null;
            Error? errorResponse = null;

            enderecoResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var enderecoResult = await service.BuscarAsync();

            List<Endereco>? response = null;
            Error? errorResponse = null;

            enderecoResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Endereco novoEndereco)
        {
            var enderecoResult = await service.CriarAsync(novoEndereco);

            Endereco? response = null;
            Error? errorResponse = null;

            enderecoResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Endereco enderecoAtualizado)
        {
            var enderecoResult = await service.AtualizarAsync(enderecoAtualizado);

            Endereco? response = null;
            Error? errorResponse = null;

            enderecoResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok(response) : BadRequest(errorResponse?.ToJson());
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var enderecoResult = await service.ExcluirAsync(id);

            int? response = null;
            Error? errorResponse = null;

            enderecoResult.Match(
                value => response = value,
                error => errorResponse = error
            );

            return response is not null ? Ok($"Quantidade de registros excluídos: {response}") : BadRequest(errorResponse?.ToJson());
        }
    }
}
