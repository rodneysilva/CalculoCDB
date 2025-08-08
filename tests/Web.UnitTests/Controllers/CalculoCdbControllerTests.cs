using CalculoCDB.Controllers;
using CalculoCDB.Domain.Interfaces.CalculoService;
using CalculoCDB.Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalculoCDB.Tests;

[TestFixture]
public class CalculoCdbControllerTests
{
    private Mock<ICalculoService> _mockCalculoService;
    private CalculoCdbController _controller;

    [SetUp]
    public void Setup()
    {
        _mockCalculoService = new Mock<ICalculoService>();
        _controller = new CalculoCdbController(_mockCalculoService.Object);
    }

    [Test]
    public void CalcularCdb_ComRequisicaoValida_DeveRetornarOkComResultado()
    {
        // Arrange
        var request = new RequisicaoInvestimentoDto
        {
            ValorInicial = 1000,
            DuracaoEmMeses = 12
        };
        var expectedResult = new ResultadoInvestimentoDto
        {
            ResultadoBruto = 100,
            ResultadoLiquido = 80
        };

        _mockCalculoService.Setup(service => service.CalcularInvestimento(request))
                           .Returns(expectedResult);

        // Act
        var actionResult = _controller.CalcularCdb(request);

        // Assert
        // Verifica se o resultado da ação é do tipo 'OkObjectResult' e não é nulo.
        Assert.That(actionResult.Result, Is.Not.Null);
        Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        var okResult = actionResult.Result as OkObjectResult;

        // A partir daqui, o compilador sabe que 'okResult' não é nulo.
        Assert.That(okResult?.Value, Is.EqualTo(expectedResult));
        _mockCalculoService.Verify(service => service.CalcularInvestimento(request), Times.Once);
    }

    [TestCase(0, 10)]
    [TestCase(-100, 10)]
    [TestCase(1000, 1)]
    [TestCase(1000, 0)]
    public void CalcularCdb_ComRequisicaoInvalida_DeveRetornarBadRequest(decimal valorInicial, int duracaoEmMeses)
    {
        // Arrange
        var request = new RequisicaoInvestimentoDto
        {
            ValorInicial = valorInicial,
            DuracaoEmMeses = duracaoEmMeses
        };

        // Act
        var actionResult = _controller.CalcularCdb(request);

        // Assert
        // Verifica se o resultado da ação é do tipo 'BadRequestObjectResult' e não é nulo.
        Assert.That(actionResult.Result, Is.Not.Null);
        Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
        var badRequestResult = actionResult.Result as BadRequestObjectResult;

        // A partir daqui, o compilador sabe que 'badRequestResult' não é nulo.
        Assert.That(badRequestResult?.Value, Is.EqualTo("O valor precisa ser acima de 0 e a duração acima de 1"));
        _mockCalculoService.Verify(service => service.CalcularInvestimento(It.IsAny<RequisicaoInvestimentoDto>()), Times.Never);
    }
}
