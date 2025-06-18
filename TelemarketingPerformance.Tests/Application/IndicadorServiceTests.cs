using Moq;
using TelemarketingPerformance.Application.DTOs;
using TelemarketingPerformance.Application.Services;
using TelemarketingPerformance.Domain.Entities;
using TelemarketingPerformance.Domain.Enums;
using TelemarketingPerformance.Domain.Repositories;

namespace TelemarketingPerformance.Tests.Application;

public class IndicadorServiceTests
{
    private readonly Mock<IIndicadorRepository> _repositoryMock;
    private readonly IIndicadorService _service;

    public IndicadorServiceTests()
    {
        _repositoryMock = new Mock<IIndicadorRepository>();
        _service = new IndicadorService(_repositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ComParametrosValidos_DeveCriarIndicador()
    {
        // Arrange
        var nome = "Média de ligações";
        var tipoDeCalculo = TipoDeCalculo.MEDIA;

        // Act
        var resultado = await _service.CreateAsync(nome, tipoDeCalculo);

        // Assert
        Assert.NotEqual(Guid.Empty, resultado.Id);
        Assert.Equal(nome, resultado.Nome);
        Assert.Equal(tipoDeCalculo, resultado.TipoDeCalculo);
        Assert.Equal(0, resultado.ResultadoAtual);
    }

    [Fact]
    public async Task AddColetaAsync_ComIndicadorExistente_DeveAdicionarColeta()
    {
        // Arrange
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);
        _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(indicador);

        // Act
        var resultado = await _service.AddColetaAsync(indicador.Id, DateTime.Now, 10);

        // Assert
        Assert.NotEqual(Guid.Empty, resultado.Id);
        Assert.Equal(indicador.Id, resultado.IndicadorId);
        Assert.Equal(10, resultado.Valor);
    }

    [Fact]
    public async Task AddColetaAsync_ComIndicadorInexistente_DeveLancarExcecao()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Indicador)null);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AddColetaAsync(Guid.NewGuid(), DateTime.Now, 10));
    }

    [Fact]
    public async Task UpdateColetaAsync_ComColetaExistente_DeveAtualizarValor()
    {
        // Arrange
        var indicador = new Indicador("Média de ligações", TipoDeCalculo.MEDIA);
        indicador.AdicionarColeta(DateTime.Now, 10);
        var coletaId = indicador.Coletas.First().Id;

        _repositoryMock.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Indicador> { indicador });

        // Act
        var resultado = await _service.UpdateColetaAsync(coletaId, 20);

        // Assert
        Assert.Equal(coletaId, resultado.Id);
        Assert.Equal(20, resultado.Valor);
    }

    [Fact]
    public async Task UpdateColetaAsync_ComColetaInexistente_DeveLancarExcecao()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Indicador>());

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateColetaAsync(Guid.NewGuid(), 20));
    }

    [Fact]
    public async Task GetByIdAsync_ComIndicadorInexistente_DeveLancarExcecao()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Indicador)null);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.GetByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task CreateAsync_ComNomeVazio_DeveCriarIndicadorComNomeVazio()
    {
        // Arrange
        var nome = string.Empty;
        var tipoDeCalculo = TipoDeCalculo.MEDIA;

        // Act
        var resultado = await _service.CreateAsync(nome, tipoDeCalculo);

        // Assert
        Assert.Equal(string.Empty, resultado.Nome);
    }
} 