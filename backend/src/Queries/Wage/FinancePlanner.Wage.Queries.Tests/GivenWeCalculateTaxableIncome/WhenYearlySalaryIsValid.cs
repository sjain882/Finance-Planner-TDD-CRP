using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Wage.Queries.Application;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;

namespace FinancePlanner.Wage.Queries.Tests.GivenWeCalculateTaxableIncome;

[TestFixture(0, 0, 0)]
[TestFixture(20000, 2000, 18000)]
public class WhenYearlySalaryIsValid
{
    [SetUp]
    public void Setup()
    {
        var sut = new GetTaxableIncome(new TaxableIncomeWageCalculatorTestHelper(), _yearlyTaxFreeAmount);
        _result = sut.CalculateYearlyWage(_inputYearlySalary);
    }

    private readonly Money _yearlyTaxFreeAmount;
    private WageResult _result;
    private readonly Money _inputYearlySalary;
    private readonly Money _expectedTaxableAmount;

    public WhenYearlySalaryIsValid(double inputYearlySalary, double yearlyTaxFreeAmount, double expectedTaxableAmount)
    {
        _yearlyTaxFreeAmount = Money.From((decimal)yearlyTaxFreeAmount);
        _inputYearlySalary = Money.From((decimal)inputYearlySalary);
        _expectedTaxableAmount = Money.From((decimal)expectedTaxableAmount);
    }

    [Test]
    public void ThenTheCorrectTaxableAmountIsCalculated()
    {
        Assert.That(_result.TaxableAmount, Is.EqualTo(_expectedTaxableAmount));
    }
}