using CalculoCDB.Application.Services.CDBService;
using CalculoCDB.Domain.Models.Dto;
using NUnit.Framework;

namespace CalculoCDB.Tests;

[TestFixture]
public class CalculoServiceTests
{
    private CalculoService _calculoService;

    [SetUp]
    public void Setup()
    {
        _calculoService = new CalculoService();
    }

    [Test]
    public void CalcularInvestimento_ComSucesso_ParaDuracaoAte6Meses()
    {
        // Arrange
        var requisicao = new RequisicaoInvestimentoDto
        {
            ValorInicial = 1000m,
            DuracaoEmMeses = 6
        };

        decimal valorFinalEsperado = 1059.76m;
        decimal resultadoBrutoEsperado = 59.76m;
        decimal resultadoLiquidoEsperado = 46.32m;
        decimal impostoRendaEsperado = 13.44m;

        // Act
        var resultado = _calculoService.CalcularInvestimento(requisicao);

        // Assert
        Assert.That(resultado.RendimentoTotal, Is.EqualTo(valorFinalEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoBruto, Is.EqualTo(resultadoBrutoEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoLiquido, Is.EqualTo(resultadoLiquidoEsperado).Within(0.01m));
        Assert.That(resultado.ImpostoRenda, Is.EqualTo(impostoRendaEsperado).Within(0.01m));
    }

    [Test]
    public void CalcularInvestimento_ComSucesso_ParaDuracaoDe7a12Meses()
    {
        // Arrange
        var requisicao = new RequisicaoInvestimentoDto
        {
            ValorInicial = 1000m,
            DuracaoEmMeses = 12
        };

        decimal valorFinalEsperado = 1123.08m;
        decimal resultadoBrutoEsperado = 123.08m;
        decimal resultadoLiquidoEsperado = 98.47m;
        decimal impostoRendaEsperado = 24.61m;

        // Act
        var resultado = _calculoService.CalcularInvestimento(requisicao);

        // Assert
        Assert.That(resultado.RendimentoTotal, Is.EqualTo(valorFinalEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoBruto, Is.EqualTo(resultadoBrutoEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoLiquido, Is.EqualTo(resultadoLiquidoEsperado).Within(0.01m));
        Assert.That(resultado.ImpostoRenda, Is.EqualTo(impostoRendaEsperado).Within(0.01m));
    }

    [Test]
    public void CalcularInvestimento_ComSucesso_ParaDuracaoDe13a24Meses()
    {
        // Arrange
        var requisicao = new RequisicaoInvestimentoDto
        {
            ValorInicial = 1000m,
            DuracaoEmMeses = 24
        };

        decimal valorFinalEsperado = 1261.31m;
        decimal resultadoBrutoEsperado = 261.31m;
        decimal resultadoLiquidoEsperado = 215.58m;
        decimal impostoRendaEsperado = 45.73m;

        // Act
        var resultado = _calculoService.CalcularInvestimento(requisicao);

        // Assert
        Assert.That(resultado.RendimentoTotal, Is.EqualTo(valorFinalEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoBruto, Is.EqualTo(resultadoBrutoEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoLiquido, Is.EqualTo(resultadoLiquidoEsperado).Within(0.01m));
        Assert.That(resultado.ImpostoRenda, Is.EqualTo(impostoRendaEsperado).Within(0.01m));
    }

    [Test]
    public void CalcularInvestimento_ComSucesso_ParaDuracaoAcimaDe24Meses()
    {
        // Arrange
        var requisicao = new RequisicaoInvestimentoDto
        {
            ValorInicial = 1000m,
            DuracaoEmMeses = 30
        };

        decimal valorFinalEsperado = 1336.68m;
        decimal resultadoBrutoEsperado = 336.68m;
        decimal resultadoLiquidoEsperado = 286.18m;
        decimal impostoRendaEsperado = 50.50m;

        // Act
        var resultado = _calculoService.CalcularInvestimento(requisicao);

        // Assert
        Assert.That(resultado.RendimentoTotal, Is.EqualTo(valorFinalEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoBruto, Is.EqualTo(resultadoBrutoEsperado).Within(0.01m));
        Assert.That(resultado.ResultadoLiquido, Is.EqualTo(resultadoLiquidoEsperado).Within(0.01m));
        Assert.That(resultado.ImpostoRenda, Is.EqualTo(impostoRendaEsperado).Within(0.01m));
    }

    [TestCase(0, 1)]
    [TestCase(-100, 10)]
    [TestCase(1000, 1)]
    [TestCase(1000, 0)]
    public void CalcularInvestimento_ComValoresInvalidos_DeveLancarExcecao(decimal valorInicial, int duracaoEmMeses)
    {
        // Arrange
        var requisicao = new RequisicaoInvestimentoDto
        {
            ValorInicial = valorInicial,
            DuracaoEmMeses = duracaoEmMeses
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculoService.CalcularInvestimento(requisicao));
    }
}
