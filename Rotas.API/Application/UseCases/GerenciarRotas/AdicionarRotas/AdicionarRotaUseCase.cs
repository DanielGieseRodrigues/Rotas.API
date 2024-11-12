using Rotas.API.Domain.Entities;
using Rotas.API.Domain.Interfaces;

namespace Rotas.API.Application.UseCases.GerenciarRotas.AdicionarRotas
{
    public class AdicionarRotaUseCase
    {
        private readonly IRotaRepository _rotaRepository;

        public AdicionarRotaUseCase(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }

        public async Task<AdicionarRotaResponse> ExecuteAsync(AdicionarRotaRequest request)
        {
            if (request == null)
                return new AdicionarRotaResponse
                {
                    Sucesso = false,
                    Mensagem = "Requisição inválida"
                };

            if (string.IsNullOrEmpty(request.Origem) || string.IsNullOrEmpty(request.Destino) || request.Valor <= 0)
                return new AdicionarRotaResponse
                {
                    Sucesso = false,
                    Mensagem = "Dados da rota inválidos"
                };

            var rota = new Rota
            {
                Origem = request.Origem.ToUpper(),
                Destino = request.Destino.ToUpper(),
                Valor = request.Valor
            };

            await _rotaRepository.AddAsync(rota);

            return new AdicionarRotaResponse
            {
                Sucesso = true,
                Mensagem = "Rota adicionada com sucesso"
            };
        }
    }
}
