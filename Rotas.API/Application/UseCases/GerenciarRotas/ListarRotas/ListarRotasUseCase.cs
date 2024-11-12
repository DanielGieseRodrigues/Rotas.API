using Rotas.API.Domain.Interfaces;

namespace Rotas.API.Application.UseCases.GerenciarRotas.ListarRotas
{
    public class ListarRotasUseCase
    {
        private readonly IRotaRepository _rotaRepository;

        public ListarRotasUseCase(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }
        public async Task<ListarRotasResponse> ExecuteAsync(ListarRotasRequest request)
        {
            var rotas = await _rotaRepository.GetAllAsync();
            return new ListarRotasResponse
            {
                Rotas = rotas.ToList()
            };
        }
    }
}
