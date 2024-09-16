using Application.Services;
using AutoFixture;
using Domain.Entities;
using Domain.Ports;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace PessoasFisicas.Tests.Application.Services
{
    public class EnderecoServiceTests
    {
        private readonly IEnderecoRepository _repository;
        private readonly EnderecoService _service;

        public EnderecoServiceTests()
        {
            _repository = Substitute.For<IEnderecoRepository>();
            _service = new EnderecoService(_repository);
        }

        [Fact]
        public async Task Atualizar_QuandoProcessoEstaCorreto_RetornaEndereco()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            _repository.AtualizarAsync(endereco).Returns(endereco);

            // Act
            var resultado = await _service.AtualizarAsync(endereco);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(endereco.Id, resultado.Value?.Id);
        }

        [Fact]
        public async Task Atualizar_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.AtualizarAsync(endereco).Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.AtualizarAsync(endereco);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task Buscar_QuandoProcessoEstaCorreto_RetornaEndereco()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            _repository.BuscarAsync(endereco.Id).Returns(endereco);

            // Act
            var resultado = await _service.BuscarAsync(endereco.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(endereco.Id, resultado.Value?.Id);
        }

        [Fact]
        public async Task Buscar_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.BuscarAsync(endereco.Id).Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.BuscarAsync(endereco.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task BuscarTodos_QuandoProcessoEstaCorreto_RetornaEndereco()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            List<Endereco> enderecos = [endereco];

            _repository.BuscarAsync().Returns(enderecos);

            // Act
            var resultado = await _service.BuscarAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(enderecos);
            Assert.Equal(endereco.Id, resultado.Value?.FirstOrDefault()?.Id);
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
        public async Task Criar_QuandoProcessoEstaCorreto_RetornaEndereco()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            _repository.CriarAsync(endereco).Returns(endereco);

            // Act
            var resultado = await _service.CriarAsync(endereco);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(endereco.Id, resultado.Value?.Id);
        }

        [Fact]
        public async Task Criar_ProcessoFalha_RetornaErro()
        {
            // Arrange
            var endereco = new Fixture().Create<Endereco>();
            var mensagemEsperada = "Erro gerado no teste.";

            _repository.CriarAsync(endereco).Throws(new Exception(mensagemEsperada));

            // Act
            var resultado = await _service.CriarAsync(endereco);

            // Assert
            Assert.NotNull(resultado);
            Assert.Contains(mensagemEsperada, resultado.Error!.Message);
        }

        [Fact]
        public async Task Excluir_QuandoProcessoEstaCorreto_RetornaEndereco()
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
