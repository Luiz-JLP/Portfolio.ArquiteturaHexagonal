namespace Application.Errors
{
    public static class PessoaFisicaErrors
    {
        public static Domain.Result.Error Atualizar(string mensagem) => new("PessoaFisica.Atualizar", mensagem);

        public static Domain.Result.Error Buscar(string mensagem) => new("PessoaFisica.Buscar", mensagem);

        public static Domain.Result.Error Criar(string mensagem) => new("PessoaFisica.Criar", mensagem);

        public static Domain.Result.Error Excluir(string mensagem) => new("PessoaFisica.Excluir", mensagem);

        public static Domain.Result.Error NomeInvalido(string mensagem) => new("PessoaFisica.NomeInvalido", mensagem);

        public static Domain.Result.Error SobrenomeInvalido(string mensagem) => new("PessoaFisica.SobrenomeInvalido", mensagem);

        public static Domain.Result.Error DataNascimentoInvalido(string mensagem) => new("PessoaFisica.DataNascimentoInvalido", mensagem);

        public static Domain.Result.Error EnderecoInvalido(string mensagem) => new("PessoaFisica.EnderecoInvalido", mensagem);
    }
}
