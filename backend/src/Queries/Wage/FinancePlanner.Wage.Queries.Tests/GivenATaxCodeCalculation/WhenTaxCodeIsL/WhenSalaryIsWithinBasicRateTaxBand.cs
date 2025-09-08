using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers.TaxCode;
using Moq;

namespace FinancePlanner.Wage.Queries.Tests.GivenATaxCodeCalculation.WhenTaxCodeIsL;

public class WhenSalaryIsWithinBasicRateAllowanceBand
{
    private WageResult _result;

    [SetUp]
    public void Setup()
    {
        var grossYearlyWageMock = new Mock<IWageCalculator>();
        grossYearlyWageMock
            .Setup(x => x.CalculateYearlyWage(It.IsAny<Money>()))
            .Returns(new WageResult
            {
                YearlySalary = Money.From(20000m)
            });

        // Tax code of 1257L = 12570 of personal allowance
        var x = new CalculateTaxCodeL(grossYearlyWageMock.Object, Money.From(12570m));

        _result = x.CalculateYearlyWage(Money.From(20000m));
    }

    [Test]
    public void ThenCorrectTaxedAmountIsCalculated()
    {
        Assert.That(_result.TaxedAmount, Is.EqualTo(Money.From(1486m)));
    }
}