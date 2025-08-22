using FinancePlanner.Queries.Wage.Application;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers.TaxCode;
using MoneyTracker.Common.Utilities.MoneyUtil;
using Moq;

namespace FinancePlanner.Queries.Wage.Tests.GivenATaxCodeCalculation.WhenTaxCodeIsL;

public class WhenSalaryIsWithinHigherRateAllowanceBand
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
                YearlySalary = Money.From(60000m)
            });

        // Tax code of 1257L = 12570 of personal allowance
        var x = new CalculateTaxCodeL(grossYearlyWageMock.Object, Money.From(12570m));

        _result = x.CalculateYearlyWage(Money.From(60000m));
    }

    [Test]
    public void ThenCorrectTaxedAmountIsCalculated()
    {
        Assert.That(_result.TaxedAmount, Is.EqualTo(Money.From(11432m)));
    }
}