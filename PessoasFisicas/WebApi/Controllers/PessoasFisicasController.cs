using Domain.Entities;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController(IPessoaFisicaService service) : Controller
    {
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Buscar(Guid id)
        {
            var pessoaFisica = await service.BuscarAsync(id);
            return Ok(pessoaFisica);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var pessoaFisica = await service.BuscarAsync();
            return Ok(pessoaFisica);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PessoaFisica novoPessoaFisica)
        {
            var pessoaFisica = await service.CriarAsync(novoPessoaFisica);
            return Ok(pessoaFisica);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(PessoaFisica pessoaFisicaAtualizado)
        {
            var pessoaFisica = await service.AtualizarAsync(pessoaFisicaAtualizado);
            return Ok(pessoaFisica);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var quantidade = await service.ExcluirAsync(id);
            return Ok($"Quantidade de registros excluídos: {quantidade}");
        }
    }
}
