using Microsoft.EntityFrameworkCore;
using TelemarketingPerformance.Domain.Entities;
using TelemarketingPerformance.Domain.Repositories;
using TelemarketingPerformance.Infrastructure.Data;

namespace TelemarketingPerformance.Infrastructure.Repositories;

public class IndicadorRepository : IIndicadorRepository
{
    private readonly ApplicationDbContext _context;

    public IndicadorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Indicador> GetByIdAsync(Guid id)
    {
        return await _context.Indicadores
            .Include(i => i.Coletas)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Indicador>> GetAllAsync()
    {
        return await _context.Indicadores
            .Include(i => i.Coletas)
            .ToListAsync();
    }

    public async Task AddAsync(Indicador indicador)
    {
        await _context.Indicadores.AddAsync(indicador);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Indicador indicador)
    {
        _context.Indicadores.Update(indicador);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var indicador = await GetByIdAsync(id);
        if (indicador != null)
        {
            _context.Indicadores.Remove(indicador);
            await _context.SaveChangesAsync();
        }
    }
} 