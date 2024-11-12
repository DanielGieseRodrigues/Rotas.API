using Moq;
using Rotas.API.Application.UseCases.CalcularMelhorRota;
using Rotas.API.Domain.Entities;
using Rotas.API.Domain.Interfaces;

namespace Rotas.API.Tests
{
    public class CalcularMelhorRotaUseCaseTests
    {
        private readonly Mock<IRotaRepository> _mockRepository;
        private readonly CalcularMelhorRotaUseCase _useCase;

        public CalcularMelhorRotaUseCaseTests()
        {
            _mockRepository = new Mock<IRotaRepository>();
            _useCase = new CalcularMelhorRotaUseCase(_mockRepository.Object);
        }

        [Fact]
        public async void DeveCalcularMelhorRota()
        {
            // Arrange
            var rotas = new List<Rota>{
            new Rota { Origem = "GRU", Destino = "BRC", Valor = 10 },
            new Rota { Origem = "BRC", Destino = "SCL", Valor = 5 },
            new Rota { Origem = "GRU", Destino = "CDG", Valor = 75 },
            new Rota { Origem = "GRU", Destino = "SCL", Valor = 20 },
            new Rota { Origem = "GRU", Destino = "ORL", Valor = 56 },
            new Rota { Origem = "ORL", Destino = "CDG", Valor = 5 },
            new Rota { Origem = "SCL", Destino = "ORL", Valor = 20 }};

            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(rotas);
            // Act
            var resultado = await _useCase.ExecuteAsync(new CalcularMelhorRotaRequest() { Origem = "GRU", Destino = "CDG" });
            // Assert
            Assert.Equal("GRU - BRC - SCL - ORL - CDG ao custo de $ 40", resultado.MelhorRota);
        }
    }
}