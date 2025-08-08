using CalculoCDB.Domain.Models.Dto;

namespace CalculoCDB.Domain.Interfaces.CalculoService;
public interface ICalculoService
{
    ResultadoInvestimentoDto CalcularInvestimento(RequisicaoInvestimentoDto requisicao);
}
