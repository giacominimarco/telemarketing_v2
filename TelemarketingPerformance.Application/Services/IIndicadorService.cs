using TelemarketingPerformance.Application.DTOs;
using TelemarketingPerformance.Domain.Enums;

namespace TelemarketingPerformance.Application.Services;

public interface IIndicadorService
{
    Task<IndicadorDTO> GetByIdAsync(Guid id);
    Task<IEnumerable<IndicadorDTO>> GetAllAsync();
    Task<IndicadorDTO> CreateAsync(string nome, TipoDeCalculo tipoDeCalculo);
    Task<ColetaDTO> AddColetaAsync(Guid indicadorId, DateTime data, decimal valor);
    Task<ColetaDTO> UpdateColetaAsync(Guid coletaId, decimal novoValor);
} 