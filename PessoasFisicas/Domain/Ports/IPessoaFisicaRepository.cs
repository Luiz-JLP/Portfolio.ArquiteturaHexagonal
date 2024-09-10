using Domain.Entities;

namespace Domain.Ports
{
    public interface IPessoaFisicaRepository
    {
        public PessoaFisica Criar(PessoaFisica PessoaFisica);

        public PessoaFisica Buscar(Guid Id);

        public IEnumerable<PessoaFisica> Buscar();

        public PessoaFisica Atualizar(PessoaFisica PessoaFisica);

        public int Excluir(Guid Id);
    }
}
