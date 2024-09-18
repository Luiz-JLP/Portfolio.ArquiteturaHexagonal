using Domain.Enumerators;

namespace Domain.Request
{
    public class EnderecoRequest
    {
        public TipoEndereco TipoEndereco { get; set; }

        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string Municipio { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Pais { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;
    }
}
