namespace CalculoCDB.Domain.Models.Dto;
public class ResultadoInvestimentoDto
{
    public decimal ResultadoBruto { get; set; }
    public decimal ResultadoLiquido { get; set; }
    public decimal RendimentoTotal { get; set; }
    public decimal ImpostoRenda {  get; set; }
}
