using Application.Services;
using AutoFixture;
using Domain.Entities;
using Domain.Ports;
using Domain.Request;
using Domain.ServiceContracts;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace PessoasFisicas.Tests.Application.Services
{
    public class PessoaFisicaServiceTests
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IEnderecoService _enderecoService;
        private readonly IEmailService _emailService;
        private readonly PessoaFisicaService _service;

        public PessoaFisicaServiceTests()
        {
            _repository = Substitute.For<IPessoaFisicaRepository>();
            _enderecoService = Substitute.For<IEnderecoService>();
            _emailService = Substitute.For<IEmailService>();
            _service = new PessoaFisicaService(_repository, _enderecoService, _emailService);
        }

        [Fact]
        public async Task Atualizar_QuandoProcessoEstaCorreto_RetornapessoaFisica()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            _repository.AtualizarAsync(pessoaFisica).Returns(pessoaFisica);

            // Act
            var resultado = await _service.AtualizarAsync(pessoaFisica);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(pessoaFisica.Id, resultado.Value?.Id);
        }

        [Fact]
        public async Task Atualizar_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.AtualizarAsync(pessoaFisica).Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.AtualizarAsync(pessoaFisica);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task Buscar_QuandoProcessoEstaCorreto_RetornapessoaFisica()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            var endereco = new Fixture().Create<Endereco>();

            _repository.BuscarAsync(pessoaFisica.Id).Returns(pessoaFisica);
            _enderecoService.BuscarAsync(pessoaFisica.Endereco).Returns(endereco);

            // Act
            var resultado = await _service.BuscarAsync(pessoaFisica.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(pessoaFisica.Id, resultado.Value?.Id);
        }

        [Fact]
        public async Task Buscar_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.BuscarAsync(pessoaFisica.Id).Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.BuscarAsync(pessoaFisica.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task BuscarTodos_QuandoProcessoEstaCorreto_RetornapessoaFisica()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            var endereco = new Fixture().Create<Endereco>();
            List<PessoaFisica> pessoaFisicas = [pessoaFisica];

            _repository.BuscarAsync().Returns(pessoaFisicas);
            _enderecoService.BuscarAsync(pessoaFisica.Endereco).Returns(endereco);

            // Act
            var resultado = await _service.BuscarAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(pessoaFisicas);
            Assert.Equal(pessoaFisica.Id, resultado.Value?.FirstOrDefault()?.Id);
        }

        [Fact]
        public async Task BuscarTodos_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.BuscarAsync().Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.BuscarAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task Criar_QuandoProcessoEstaCorreto_RetornapessoaFisica()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            var request = new Fixture().Create<PessoaFisicaRequest>();

            _repository.CriarAsync(pessoaFisica).ReturnsForAnyArgs(pessoaFisica);

            // Act
            var resultado = await _service.CriarAsync(request);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(pessoaFisica.Id, resultado.Value?.Id);
        }

        [Fact]
        public async Task Criar_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var pessoaFisica = new Fixture().Create<PessoaFisica>();
            var request = new Fixture().Create<PessoaFisicaRequest>();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.CriarAsync(pessoaFisica).ThrowsAsyncForAnyArgs(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.CriarAsync(request);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task Excluir_QuandoProcessoEstaCorreto_RetornapessoaFisica()
        {
            // Arrange
            var id = Guid.NewGuid();
            var retorno = 1;

            _repository.ExcluirAsync(id).Returns(retorno);

            // Act
            var resultado = await _service.ExcluirAsync(id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(retorno, resultado.Value!);
        }

        [Fact]
        public async Task Excluir_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.ExcluirAsync(id).Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.ExcluirAsync(id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }
    }
}
