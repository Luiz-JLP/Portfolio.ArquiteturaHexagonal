using Domain.Entities;

namespace Domain.Ports
{
    public interface IEnderecoRepository
    {
        public Endereco Criar(Endereco endereco);

        public Endereco Buscar(Guid Id);

        public IEnumerable<Endereco> Buscar();

        public Endereco Atualizar(Endereco endereco);

        public int Excluir(Guid Id);
    }
}
