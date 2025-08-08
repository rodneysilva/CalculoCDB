namespace CalculoCDB.Domain.Models.CDB;
public class CdbModel
{
    public decimal ValorInicial { get; private set; }
    public int DuracaoEmMeses { get; private set; }

    public CdbModel(decimal valorInicial, int duracaoEmMeses)
    {
        if (valorInicial <= 0)
            throw new ArgumentException("O valor inicial deve ser positivo.", nameof(valorInicial));

        if (duracaoEmMeses <= 1)
            throw new ArgumentException("A duração em meses deve ser maior que um.", nameof(duracaoEmMeses));

        ValorInicial = valorInicial;
        DuracaoEmMeses = duracaoEmMeses;
    }

    public decimal CalcularValorFinal(decimal cdi, decimal tb)
    {
        decimal valorFinal = ValorInicial;

        for (int mes = 1; mes <= DuracaoEmMeses; mes++)
        {
            valorFinal *= 1 + cdi * tb;
        }

        return valorFinal;
    }
}
