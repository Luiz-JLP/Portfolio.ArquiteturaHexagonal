namespace Domain.Request
{
    public class PessoaFisicaRequest
    {
        public string Nome { get; set; } = string.Empty;

        public string Sobrenome { get; set; } = string.Empty;

        public DateTime Nascimento { get; set; }

        public Guid Endereco { get; set; }
    }
}
