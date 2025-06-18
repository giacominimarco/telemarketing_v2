namespace TelemarketingPerformance.Application.DTOs;

public class ColetaDTO
{
    public Guid Id { get; set; }
    public Guid IndicadorId { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
} 