namespace Application.Result
{
    public static class PessoaFisicaErrors
    {
        public static Error NomeInvalido(string mensagem) => new("PessoaFisica.NomeInvalido", mensagem);

        public static Error SobrenomeInvalido(string mensagem) => new("PessoaFisica.SobrenomeInvalido", mensagem);

        public static Error DataNascimentoInvalido(string mensagem) => new("PessoaFisica.DataNascimentoInvalido", mensagem);

        public static Error EnderecoInvalido(string mensagem) => new("PessoaFisica.EnderecoInvalido", mensagem);
    }
}
