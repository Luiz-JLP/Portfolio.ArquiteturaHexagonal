﻿using Domain.Entities;

namespace Domain.Ports
{
    public interface IPessoaFisicaRepository
    {
        public Task<PessoaFisica> CriarAsync(PessoaFisica PessoaFisica);

        public Task<PessoaFisica> BuscarAsync(Guid Id);

        public Task<IEnumerable<PessoaFisica>> BuscarAsync();

        public Task<PessoaFisica> AtualizarAsync(PessoaFisica PessoaFisica);

        public Task<int> ExcluirAsync(Guid Id);
    }
}
