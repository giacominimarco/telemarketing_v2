using TelemarketingPerformance.Domain.Enums;

namespace TelemarketingPerformance.Application.DTOs;

public class IndicadorDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public TipoDeCalculo TipoDeCalculo { get; set; }
    public decimal ResultadoAtual { get; set; }
} 