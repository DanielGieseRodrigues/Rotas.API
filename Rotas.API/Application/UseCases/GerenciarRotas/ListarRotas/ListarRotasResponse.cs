using Rotas.API.Domain.Entities;

namespace Rotas.API.Application.UseCases.GerenciarRotas.ListarRotas
{
    public class ListarRotasResponse
    {
        public List<Rota> Rotas { get; set; } = [];
    }
}
