using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculator.Handlers;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Tests.GivenWeCalculateTaxableIncome;

[TestFixture(0, 0, 0)]
[TestFixture(20000, 2000, 18000)]
public class WhenYearlySalaryIsValid
{
    private readonly decimal _yearlyTaxFreeAmount;
    private WageResult _result;
    private readonly decimal _inputYearlySalary;
    private readonly decimal _expectedTaxableAmount;

    public WhenYearlySalaryIsValid(double inputYearlySalary, double yearlyTaxFreeAmount, double expectedTaxableAmount)
    {
        _yearlyTaxFreeAmount = (decimal)yearlyTaxFreeAmount;
        _inputYearlySalary = (decimal)inputYearlySalary;
        _expectedTaxableAmount = (decimal)expectedTaxableAmount;
    }

    [SetUp]
    public void Setup()
    {
        var sut = new GetTaxableIncome(new TaxableIncomeWageCalculatorTestHelper(), _yearlyTaxFreeAmount);
        _result = sut.CalculateYearlyWage(_inputYearlySalary);
    }
    
    [Test]
    public void ThenTheCorrectTaxableAmountIsCalculated()
    {
        Assert.That(_result.TaxableAmount, Is.EqualTo(_expectedTaxableAmount));
    }
}