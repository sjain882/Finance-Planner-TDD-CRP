using FinancePlanner.Queries.Wage.Application;
using FinancePlanner.Queries.Wage.Application.TaxCode;
using Moq;

namespace FinancePlanner.Queries.Wage.Tests.GivenATaxCodeCalculation.WhenTaxCodeIsL;

public class WhenSalaryIsWithinBasicRateAllowanceBand
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
                YearlySalary = 20000m
            });

        // Tax code of 1257L = 12570 of personal allowance
        var x = new CalculateTaxCodeL(grossYearlyWageMock.Object, 12570m);

        _result = x.CalculateYearlyWage(20000);
    }

    [Test]
    public void ThenCorrectTaxedAmountIsCalculated()
    {
        Assert.That(_result.TaxedAmount, Is.EqualTo(1486));
    }
}