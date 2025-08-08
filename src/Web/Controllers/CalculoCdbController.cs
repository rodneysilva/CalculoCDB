using CalculoCDB.Domain.Interfaces.CalculoService;
using CalculoCDB.Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculoCdbController : ControllerBase
{

    private readonly ICalculoService _calculoService;

    public CalculoCdbController(ICalculoService calculoService)
    {
        _calculoService = calculoService;
    }

    [HttpPost("calcular-cdb")]
    public ActionResult<ResultadoInvestimentoDto> CalcularCdb([FromBody] RequisicaoInvestimentoDto request)
    {
        if (request == null || request.ValorInicial <= 0 || request.DuracaoEmMeses <= 1)
        {
            return BadRequest("O valor precisa ser acima de 0 e a duração acima de 1");
        }

        var result = _calculoService.CalcularInvestimento(request);
        return Ok(result);
    }
}
