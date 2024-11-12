using Rotas.API.Domain.Entities;

namespace Rotas.API.Domain.Interfaces
{
    public interface IRotaRepository
    {
        Task AddAsync(Rota rota);
        Task<IEnumerable<Rota>> GetAllAsync();
        Task<Rota?> GetByIdAsync(int id);
        Task RemoveAsync(Rota rota);
        Task UpdateAsync(Rota rota);
    }
}
