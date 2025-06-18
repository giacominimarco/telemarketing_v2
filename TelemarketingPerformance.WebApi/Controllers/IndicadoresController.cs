using Microsoft.AspNetCore.Mvc;
using TelemarketingPerformance.Application.DTOs;
using TelemarketingPerformance.Application.Services;
using TelemarketingPerformance.Domain.Enums;

namespace TelemarketingPerformance.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndicadoresController : ControllerBase
{
    private readonly IIndicadorService _indicadorService;

    public IndicadoresController(IIndicadorService indicadorService)
    {
        _indicadorService = indicadorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IndicadorDTO>>> GetAll()
    {
        var indicadores = await _indicadorService.GetAllAsync();
        return Ok(indicadores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IndicadorDTO>> GetById(Guid id)
    {
        try
        {
            var indicador = await _indicadorService.GetByIdAsync(id);
            return Ok(indicador);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<IndicadorDTO>> Create([FromBody] CreateIndicadorRequest request)
    {
        var indicador = await _indicadorService.CreateAsync(request.Nome, request.TipoDeCalculo);
        return CreatedAtAction(nameof(GetById), new { id = indicador.Id }, indicador);
    }

    [HttpPost("{id}/coletas")]
    public async Task<ActionResult<ColetaDTO>> AddColeta(Guid id, [FromBody] AddColetaRequest request)
    {
        try
        {
            var coleta = await _indicadorService.AddColetaAsync(id, request.Data, request.Valor);
            return Ok(coleta);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("coletas/{id}")]
    public async Task<ActionResult<ColetaDTO>> UpdateColeta(Guid id, [FromBody] UpdateColetaRequest request)
    {
        try
        {
            var coleta = await _indicadorService.UpdateColetaAsync(id, request.Valor);
            return Ok(coleta);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

public class CreateIndicadorRequest
{
    public string Nome { get; set; }
    public TipoDeCalculo TipoDeCalculo { get; set; }
}

public class AddColetaRequest
{
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
}

public class UpdateColetaRequest
{
    public decimal Valor { get; set; }
} 