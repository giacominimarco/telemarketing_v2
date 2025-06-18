using TelemarketingPerformance.Domain.Entities;
using TelemarketingPerformance.Domain.Enums;

namespace TelemarketingPerformance.Tests.Domain;

public class IndicadorTests
{
    [Fact]
    public void CriarIndicador_ComParametrosValidos_DeveCriarIndicador()
    {
        // Arrange & Act
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);

        // Assert
        Assert.NotEqual(Guid.Empty, indicador.Id);
        Assert.Equal("Média de ligações", indicador.Nome);
        Assert.Equal(TipoDeCalculo.MEDIA, indicador.TipoDeCalculo);
        Assert.Empty(indicador.Coletas);
    }

    [Fact]
    public void CalcularResultado_SemColetas_DeveRetornarZero()
    {
        // Arrange
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);

        // Act
        var resultado = indicador.CalcularResultado();

        // Assert
        Assert.Equal(0, resultado);
    }

    [Fact]
    public void CalcularResultado_ComUmaColeta_DeveRetornarValorDaColeta()
    {
        // Arrange
        var indicador = new Indicador("Total de Vendas", TipoDeCalculo.SOMA);
        indicador.AdicionarColeta(DateTime.Now, 123.45m);

        // Act
        var resultado = indicador.CalcularResultado();

        // Assert
        Assert.Equal(123.45m, resultado);
    }

    [Fact]
    public void CalcularResultado_ComTipoMedia_DeveCalcularMediaCorretamente()
    {
        // Arrange
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);
        indicador.AdicionarColeta(DateTime.Now, 10);
        indicador.AdicionarColeta(DateTime.Now, 20);
        indicador.AdicionarColeta(DateTime.Now, 30);

        // Act
        var resultado = indicador.CalcularResultado();

        // Assert
        Assert.Equal(20, resultado);
    }

    [Fact]
    public void CalcularResultado_ComTipoSoma_DeveCalcularSomaCorretamente()
    {
        // Arrange
        var indicador = new Indicador("Total de Vendas", TipoDeCalculo.SOMA);
        indicador.AdicionarColeta(DateTime.Now, 100);
        indicador.AdicionarColeta(DateTime.Now, 200);
        indicador.AdicionarColeta(DateTime.Now, 300);

        // Act
        var resultado = indicador.CalcularResultado();

        // Assert
        Assert.Equal(600, resultado);
    }

    [Fact]
    public void AtualizarColeta_ComColetaExistente_DeveAtualizarValor()
    {
        // Arrange
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);
        indicador.AdicionarColeta(DateTime.Now, 10);
        var coletaId = indicador.Coletas.First().Id;

        // Act
        indicador.AtualizarColeta(coletaId, 20);

        // Assert
        Assert.Equal(20, indicador.Coletas.First().Valor);
    }

    [Fact]
    public void AtualizarColeta_ComColetaInexistente_DeveLancarExcecao()
    {
        // Arrange
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => 
            indicador.AtualizarColeta(Guid.NewGuid(), 20));
    }
} 