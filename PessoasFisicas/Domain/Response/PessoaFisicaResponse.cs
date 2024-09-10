using Domain.Entities;

namespace Domain.Response
{
    public class PessoaFisicaResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Sobrenome { get; set; } = string.Empty;

        public DateTime Nascimento { get; set; }

        public Endereco Endereco { get; set; } = new();
    }
}
