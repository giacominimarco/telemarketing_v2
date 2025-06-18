namespace TelemarketingPerformance.Domain.Entities;

public class Coleta
{
    public Guid Id { get; private set; }
    public Guid IndicadorId { get; private set; }
    public DateTime Data { get; private set; }
    public decimal Valor { get; private set; }
    public Indicador Indicador { get; private set; }

    private Coleta() { } // For EF Core

    public Coleta(Indicador indicador, DateTime data, decimal valor)
    {
        Id = Guid.NewGuid();
        IndicadorId = indicador.Id;
        Data = data;
        Valor = valor;
        Indicador = indicador;
    }

    public void AtualizarValor(decimal novoValor)
    {
        Valor = novoValor;
    }
} 