using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.WageCalculators;
using FinancePlanner.Core.WageCalculators.Handlers.TaxCode;
using Moq;

namespace FinancePlanner.Tests.GivenATaxCodeCalculation.WhenTaxCodeIsL;

public class WhenSalaryIsWithinPersonalAllowanceBand
{
    private HandlerResult _result;

    [SetUp]
    public void Setup()
    {
        var grossYearlyWageMock = new Mock<IHandler>();
        grossYearlyWageMock
            .Setup(x => x.Handle(It.IsAny<decimal>()))
            .Returns(new HandlerResult
            {
                YearlySalary = 10000m,
            });
        
        // Tax code of 1257L = 12570 of personal allowance
        var x = new CalculateTaxCodeLHandler(grossYearlyWageMock.Object, 12570m);

        _result = x.Handle(10000);
    }

    [Test]
    public void ThenCorrectTaxedAmountIsCalculated()
    {
        Assert.That(_result.TaxedAmount, Is.EqualTo(0));
    }
}