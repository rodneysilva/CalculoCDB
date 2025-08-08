using CalculoCDB.Domain.Models.Dto;
using CalculoCDB.Domain.Interfaces.CalculoService;

namespace CalculoCDB.Application.Services.CDBService;
public class CalculoService : ICalculoService
{
    private const decimal TB = 1.08m; // 108%
    private const decimal CDI = 0.009m; // 0.9%

    public ResultadoInvestimentoDto CalcularInvestimento(RequisicaoInvestimentoDto requisicao)
    {
        if (requisicao.ValorInicial <= 0 || requisicao.DuracaoEmMeses <= 1)
        {
            throw new ArgumentException("O valor inicial deve ser positivo e a duração deve ser maior que 1 mês.");
        }

        decimal valorFinal = CalcularValorFinal(requisicao.ValorInicial, requisicao.DuracaoEmMeses);
        decimal resultadoBruto = valorFinal - requisicao.ValorInicial;
        decimal resultadoLiquido = CalcularResultadoLiquido(resultadoBruto, requisicao.DuracaoEmMeses);

        return new ResultadoInvestimentoDto
        {
            ResultadoBruto = resultadoBruto,
            ResultadoLiquido = resultadoLiquido,
            RendimentoTotal = requisicao.ValorInicial + resultadoBruto,
            ImpostoRenda = resultadoBruto - resultadoLiquido
        };
    }

    private decimal CalcularValorFinal(decimal valorInicial, int duracaoEmMeses)
    {
        decimal valorFinal = valorInicial;

        for (int mes = 1; mes <= duracaoEmMeses; mes++)
        {
            valorFinal *= (1 + (CDI * TB));
        }

        return valorFinal;
    }

    private decimal CalcularResultadoLiquido(decimal resultadoBruto, int duracaoEmMeses)
    {
        decimal aliquota = ObterAliquota(duracaoEmMeses);
        return resultadoBruto * (1 - aliquota);
    }

    private decimal ObterAliquota(int duracaoEmMeses)
    {
        if (duracaoEmMeses <= 6) return 0.225m; // 22,5%
        if (duracaoEmMeses <= 12) return 0.20m; // 20%
        if (duracaoEmMeses <= 24) return 0.175m; // 17,5%
        return 0.15m; // 15%
    }
}
