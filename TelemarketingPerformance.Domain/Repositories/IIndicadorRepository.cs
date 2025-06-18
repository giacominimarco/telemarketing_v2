using TelemarketingPerformance.Domain.Entities;

namespace TelemarketingPerformance.Domain.Repositories;

public interface IIndicadorRepository
{
    Task<Indicador> GetByIdAsync(Guid id);
    Task<IEnumerable<Indicador>> GetAllAsync();
    Task AddAsync(Indicador indicador);
    Task UpdateAsync(Indicador indicador);
    Task DeleteAsync(Guid id);
} 