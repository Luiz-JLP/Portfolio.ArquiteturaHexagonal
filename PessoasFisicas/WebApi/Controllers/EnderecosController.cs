using Domain.Entities;
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
            var endereco = await service.BuscarAsync(id);
            return Ok(endereco);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var endereco = await service.BuscarAsync();
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Endereco novoEndereco)
        {
            var endereco = await service.CriarAsync(novoEndereco);
            return Ok(endereco);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Endereco enderecoAtualizado)
        {
            var endereco = await service.AtualizarAsync(enderecoAtualizado);
            return Ok(endereco);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var quantidade = await service.ExcluirAsync(id);
            return Ok($"Quantidade de registros excluídos: {quantidade}");
        }
    }
}
