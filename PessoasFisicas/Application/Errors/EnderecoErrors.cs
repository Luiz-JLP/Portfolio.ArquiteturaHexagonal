using Domain.Result;
using System.Diagnostics.CodeAnalysis;

namespace Application.Errors
{
    [ExcludeFromCodeCoverage]
    public static class EnderecoErrors
    {
        public static Error Atualizar(string mensagem) => new("Endereco.Atualizar", mensagem);

        public static Error Buscar(string mensagem) => new("Endereco.Buscar", mensagem);

        public static Error Criar(string mensagem) => new("Endereco.Criar", mensagem);

        public static Error Excluir(string mensagem) => new("Endereco.Excluir", mensagem);
    }
}

