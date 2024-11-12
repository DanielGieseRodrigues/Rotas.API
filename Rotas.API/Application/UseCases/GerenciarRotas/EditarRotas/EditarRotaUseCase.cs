using Rotas.API.Application.UseCases.GerenciarRotas.AdicionarRotas;
using Rotas.API.Domain.Interfaces;

namespace Rotas.API.Application.UseCases.GerenciarRotas.EditarRotas
{
    public class EditarRotaUseCase
    {
        private readonly IRotaRepository _rotaRepository;

        public EditarRotaUseCase(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }

        public async Task<EditarRotaResponse> ExecuteAsync(EditarRotaRequest request)
        {
            var rota = await _rotaRepository.GetByIdAsync(request.RotaId);

            if (rota == null)
            {
                throw new Exception("Rota não encontrada.");
            }

            if (string.IsNullOrEmpty(request.Origem) || string.IsNullOrEmpty(request.Destino) || request.Valor <= 0)
                return new EditarRotaResponse
                {
                    Sucesso = false,
                    Mensagem = "Dados da rota inválidos"
                };

            rota.Origem = request.Origem.ToUpper();
            rota.Destino = request.Destino.ToUpper();
            rota.Valor = request.Valor;

            await _rotaRepository.UpdateAsync(rota);

            return new EditarRotaResponse
            {
                Sucesso = true,
                Mensagem = "Rota atualizada com sucesso."
            };
        }
    }
}
