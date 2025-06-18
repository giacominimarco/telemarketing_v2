using TelemarketingPerformance.Application.DTOs;
using TelemarketingPerformance.Domain.Entities;
using TelemarketingPerformance.Domain.Enums;
using TelemarketingPerformance.Domain.Repositories;

namespace TelemarketingPerformance.Application.Services;

public class IndicadorService : IIndicadorService
{
    private readonly IIndicadorRepository _indicadorRepository;

    public IndicadorService(IIndicadorRepository indicadorRepository)
    {
        _indicadorRepository = indicadorRepository;
    }

    public async Task<IndicadorDTO> GetByIdAsync(Guid id)
    {
        var indicador = await _indicadorRepository.GetByIdAsync(id);
        if (indicador == null)
            throw new InvalidOperationException("Indicador não encontrado");

        return MapToDTO(indicador);
    }

    public async Task<IEnumerable<IndicadorDTO>> GetAllAsync()
    {
        var indicadores = await _indicadorRepository.GetAllAsync();
        return indicadores.Select(MapToDTO);
    }

    public async Task<IndicadorDTO> CreateAsync(string nome, TipoDeCalculo tipoDeCalculo)
    {
        var indicador = new Indicador(nome, tipoDeCalculo);
        await _indicadorRepository.AddAsync(indicador);
        return MapToDTO(indicador);
    }

    public async Task<ColetaDTO> AddColetaAsync(Guid indicadorId, DateTime data, decimal valor)
    {
        var indicador = await _indicadorRepository.GetByIdAsync(indicadorId);
        if (indicador == null)
            throw new InvalidOperationException("Indicador não encontrado");

        indicador.AdicionarColeta(data, valor);
        await _indicadorRepository.UpdateAsync(indicador);

        var coleta = indicador.Coletas.Last();
        return new ColetaDTO
        {
            Id = coleta.Id,
            IndicadorId = coleta.IndicadorId,
            Data = coleta.Data,
            Valor = coleta.Valor
        };
    }

    public async Task<ColetaDTO> UpdateColetaAsync(Guid coletaId, decimal novoValor)
    {
        var indicadores = await _indicadorRepository.GetAllAsync();
        var indicador = indicadores.FirstOrDefault(i => i.Coletas.Any(c => c.Id == coletaId));
        
        if (indicador == null)
            throw new InvalidOperationException("Coleta não encontrada");

        indicador.AtualizarColeta(coletaId, novoValor);
        await _indicadorRepository.UpdateAsync(indicador);

        var coleta = indicador.Coletas.First(c => c.Id == coletaId);
        return new ColetaDTO
        {
            Id = coleta.Id,
            IndicadorId = coleta.IndicadorId,
            Data = coleta.Data,
            Valor = coleta.Valor
        };
    }

    private static IndicadorDTO MapToDTO(Indicador indicador)
    {
        return new IndicadorDTO
        {
            Id = indicador.Id,
            Nome = indicador.Nome,
            TipoDeCalculo = indicador.TipoDeCalculo,
            ResultadoAtual = indicador.CalcularResultado()
        };
    }
} 