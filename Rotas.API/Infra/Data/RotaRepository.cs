using Microsoft.EntityFrameworkCore;
using Rotas.API.Domain.Entities;
using Rotas.API.Domain.Interfaces;
using Rotas.API.Infra.Data;

namespace Infrastructure.Data
{
    public class RotaRepository : IRotaRepository
    {
        private readonly RotaContext _context;

        public RotaRepository(RotaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rota rota)
        {
            _context.Rotas.Add(rota);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rota>> GetAllAsync()
        {
            return await _context.Rotas.ToListAsync();
        }

        public async Task<Rota?> GetByIdAsync(int id)
        {
            return await _context.Rotas.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task RemoveAsync(Rota rota)
        {
            if (rota != null)
            {
                _context.Rotas.Remove(rota);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Rota rota)
        {
            _context.Rotas.Update(rota); 
            await _context.SaveChangesAsync();
        }
    }
}
