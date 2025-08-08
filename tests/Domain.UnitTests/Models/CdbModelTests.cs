using CalculoCDB.Domain.Models.CDB;
using NUnit.Framework;

namespace CalculoCDB.Tests;

[TestFixture]
public class CdbModelTests
{
    [Test]
    public void Construtor_ComValoresValidos_DeveCriarInstanciaCorretamente()
    {
        // Arrange
        decimal valorInicial = 1000m;
        int duracaoEmMeses = 12;

        // Act
        var cdb = new CdbModel(valorInicial, duracaoEmMeses);

        // Assert
        Assert.That(cdb.ValorInicial, Is.EqualTo(valorInicial));
        Assert.That(cdb.DuracaoEmMeses, Is.EqualTo(duracaoEmMeses));
    }

    [TestCase(0, 10)]
    [TestCase(-100, 10)]
    public void Construtor_ComValorInicialInvalido_DeveLancarExcecao(decimal valorInicial, int duracaoEmMeses)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CdbModel(valorInicial, duracaoEmMeses));
    }

    [TestCase(1000, 1)]
    [TestCase(1000, 0)]
    [TestCase(1000, -5)]
    public void Construtor_ComDuracaoInvalida_DeveLancarExcecao(decimal valorInicial, int duracaoEmMeses)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CdbModel(valorInicial, duracaoEmMeses));
    }

    [Test]
    public void CalcularValorFinal_ComCDIETBPadrao_ParaDuracaoAte6Meses()
    {
        // Arrange
        decimal valorInicial = 1000m;
        int duracaoEmMeses = 6;
        decimal cdi = 0.009m;
        decimal tb = 1.08m;
        var cdb = new CdbModel(valorInicial, duracaoEmMeses);

        // Act
        var valorFinal = cdb.CalcularValorFinal(cdi, tb);

        // Assert
        Assert.That(valorFinal, Is.EqualTo(1059.7556m).Within(0.01m));
    }

    [Test]
    public void CalcularValorFinal_ComCDIETBPadrao_ParaDuracaoDe12Meses()
    {
        // Arrange
        decimal valorInicial = 1000m;
        int duracaoEmMeses = 12;
        decimal cdi = 0.009m;
        decimal tb = 1.08m;
        var cdb = new CdbModel(valorInicial, duracaoEmMeses);

        // Act
        var valorFinal = cdb.CalcularValorFinal(cdi, tb);

        // Assert
        Assert.That(valorFinal, Is.EqualTo(1123.0820m).Within(0.01m));
    }

    [Test]
    public void CalcularValorFinal_ComCDIETBPadrao_ParaDuracaoDe24Meses()
    {
        // Arrange
        decimal valorInicial = 1000m;
        int duracaoEmMeses = 24;
        decimal cdi = 0.009m;
        decimal tb = 1.08m;
        var cdb = new CdbModel(valorInicial, duracaoEmMeses);

        // Act
        var valorFinal = cdb.CalcularValorFinal(cdi, tb);

        // Assert
        Assert.That(valorFinal, Is.EqualTo(1261.3133m).Within(0.01m));
    }
}
