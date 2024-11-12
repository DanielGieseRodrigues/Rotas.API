using Moq;
using Rotas.API.Domain.Entities;
using Rotas.API.Domain.Interfaces;
using Rotas.API.Application.UseCases.GerenciarRotas.AdicionarRotas;
using Rotas.API.Application.UseCases.GerenciarRotas.EditarRotas;
using Rotas.API.Application.UseCases.GerenciarRotas.ExcluirRota;
using Rotas.API.Application.UseCases.GerenciarRotas.ListarRotas;

namespace Rotas.API.Tests
{
    public class GerenciarRotasUseCasesTests
    {
        private readonly Mock<IRotaRepository> _mockRepository;
        private readonly AdicionarRotaUseCase _adicionarUseCase;
        private readonly EditarRotaUseCase _editarUseCase;
        private readonly ExcluirRotaUseCase _excluirUseCase;
        private readonly ListarRotasUseCase _listarUseCase;

        public GerenciarRotasUseCasesTests()
        {
            _mockRepository = new Mock<IRotaRepository>();
            _adicionarUseCase = new AdicionarRotaUseCase(_mockRepository.Object);
            _editarUseCase = new EditarRotaUseCase(_mockRepository.Object);
            _excluirUseCase = new ExcluirRotaUseCase(_mockRepository.Object);
            _listarUseCase = new ListarRotasUseCase(_mockRepository.Object);
        }

        [Fact]
        public async Task DeveAdicionarNovaRota()
        {
            // Arrange
            var request = new AdicionarRotaRequest { Origem = "GRU", Destino = "JFK", Valor = 100 };
            var rota = new Rota { Origem = "GRU", Destino = "JFK", Valor = 100 };
            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Rota>())).Returns(Task.FromResult(rota));

            // Act
            var resultado = await _adicionarUseCase.ExecuteAsync(request);

            // Assert
            Assert.True(resultado.Sucesso);
            Assert.Equal("Rota adicionada com sucesso", resultado.Mensagem);
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Rota>()), Times.Once);

        }

        [Fact]
        public async Task DeveEditarRota()
        {
            // Arrange
            var request = new EditarRotaRequest { RotaId = 1, Origem = "GRU", Destino = "LAX", Valor = 150 };
            var rotaEditada = new Rota { Id = 1, Origem = "GRU", Destino = "LAX", Valor = 150 };

            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rotaEditada);
            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Rota>())).Returns(Task.CompletedTask);

            // Act
            var resultado = await _editarUseCase.ExecuteAsync(request);

            // Assert
            Assert.True(resultado.Sucesso);
            Assert.Equal("Rota atualizada com sucesso.", resultado.Mensagem);
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Rota>()), Times.Once);
        }

        [Fact]
        public async Task DeveExcluirRota()
        {
            // Arrange
            var rota = new Rota() { Id = 1, Destino = "GRU", Origem = "BRC" };

            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rota);
            _mockRepository.Setup(r => r.RemoveAsync(rota)).Returns(Task.CompletedTask);

            // Act
            var resultado = await _excluirUseCase.ExecuteAsync(new ExcluirRotaRequest { RotaId = rota.Id });

            // Assert
            Assert.True(resultado.Sucesso);
            Assert.Equal("Rota excluída com sucesso.", resultado.Mensagem);
            _mockRepository.Verify(r => r.RemoveAsync(rota), Times.Once);
        }

        [Fact]
        public async Task DeveListarTodasAsRotas()
        {
            // Arrange
            var rotas = new List<Rota>
            {
                new Rota { Origem = "GRU", Destino = "BRC", Valor = 10 },
                new Rota { Origem = "BRC", Destino = "SCL", Valor = 5 }
            };
            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(rotas);

            // Act
            var resultado = await _listarUseCase.ExecuteAsync(new ListarRotasRequest());

            // Assert
            Assert.Equal(rotas.Count, resultado.Rotas.Count);
            _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }
    }
}
