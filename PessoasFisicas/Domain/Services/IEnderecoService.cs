using Domain.Entities;

namespace Domain.Services
{
    public interface IEnderecoService
    {
        public Endereco Criar(Endereco endereco);

        public Endereco Buscar(Guid Id);

        public IEnumerable<Endereco> Buscar();

        public Endereco Atualizar(Endereco endereco);

        public int Excluir(Guid Id);
    }
}
