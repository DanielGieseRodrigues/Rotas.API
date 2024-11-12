using Rotas.API.Domain.Interfaces;

namespace Rotas.API.Application.UseCases.GerenciarRotas.ExcluirRota
{
    public class ExcluirRotaUseCase
    {
        private readonly IRotaRepository _rotaRepository;

        public ExcluirRotaUseCase(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }

        public async Task<ExcluirRotaResponse> ExecuteAsync(ExcluirRotaRequest request)
        {
            var rota = await _rotaRepository.GetByIdAsync(request.RotaId);
            if (rota == null)
                throw new Exception("Rota não encontrada.");

            await _rotaRepository.RemoveAsync(rota);

            return new ExcluirRotaResponse
            {
                Sucesso = true,
                Mensagem = "Rota excluída com sucesso."
            };
        }
    }
}
