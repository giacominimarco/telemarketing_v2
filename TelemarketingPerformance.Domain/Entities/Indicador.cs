using TelemarketingPerformance.Domain.Enums;

namespace TelemarketingPerformance.Domain.Entities;

public class Indicador
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public TipoDeCalculo TipoDeCalculo { get; private set; }
    public ICollection<Coleta> Coletas { get; private set; }

    private Indicador() { Coletas = new List<Coleta>(); } // For EF Core

    public Indicador(string nome, TipoDeCalculo tipoDeCalculo)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        TipoDeCalculo = tipoDeCalculo;
        Coletas = new List<Coleta>();
    }

    public decimal CalcularResultado()
    {
        if (!Coletas.Any())
            return 0;

        return TipoDeCalculo switch
        {
            TipoDeCalculo.SOMA => Coletas.Sum(c => c.Valor),
            TipoDeCalculo.MEDIA => Coletas.Average(c => c.Valor),
            _ => throw new InvalidOperationException("Tipo de cálculo não suportado")
        };
    }

    public void AdicionarColeta(DateTime data, decimal valor)
    {
        var coleta = new Coleta(this, data, valor);
        Coletas.Add(coleta);
    }

    public void AtualizarColeta(Guid coletaId, decimal novoValor)
    {
        var coleta = Coletas.FirstOrDefault(c => c.Id == coletaId);
        if (coleta == null)
            throw new InvalidOperationException("Coleta não encontrada");

        coleta.AtualizarValor(novoValor);
    }
} 