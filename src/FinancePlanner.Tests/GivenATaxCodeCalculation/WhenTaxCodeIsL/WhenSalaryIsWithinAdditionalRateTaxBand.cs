using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.WageCalculators;
using FinancePlanner.Core.WageCalculators.Handlers.TaxCode;
using Moq;

namespace FinancePlanner.Tests.GivenATaxCodeCalculation.WhenTaxCodeIsL;

public class WhenSalaryIsWithinAdditionalRateAllowanceBand
{
    private WageResult _result;

    [SetUp]
    public void Setup()
    {
        var grossYearlyWageMock = new Mock<IWageCalculator>();
        grossYearlyWageMock
            .Setup(x => x.CalculateYearlyWage(It.IsAny<decimal>()))
            .Returns(new WageResult
            {
                YearlySalary = 130000m
            });

        // Tax code of 1257L = 12570 of personal allowance
        var x = new CalculateTaxCodeL(grossYearlyWageMock.Object, 12570m);

        _result = x.CalculateYearlyWage(130000);
    }

    [Test]
    public void ThenCorrectTaxedAmountIsCalculated()
    {
        Assert.That(_result.TaxedAmount, Is.EqualTo(39675));
    }
}