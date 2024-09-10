using Domain.Entities;

namespace Application.Contracts
{
    public interface IPessoaFisicaService
    {
        public PessoaFisica Criar(PessoaFisica PessoaFisica);

        public PessoaFisica Buscar(Guid Id);

        public IEnumerable<PessoaFisica> Buscar();

        public PessoaFisica Atualizar(PessoaFisica PessoaFisica);

        public int Excluir(Guid Id);
    }
}
