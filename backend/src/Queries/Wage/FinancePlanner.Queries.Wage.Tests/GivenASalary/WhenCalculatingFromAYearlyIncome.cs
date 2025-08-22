using FinancePlanner.Queries.Wage.Application;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Tests.GivenASalary;

// Injects into setup instead of method for class wide test
[TestFixture(1, 1)]
[TestFixture(20000, 20000)]
public class WhenCalculatingFromAYearlyIncome
{
    [SetUp]
    public void Setup()
    {
        var sut = new FromYearlySalary();
        _actualSalary = sut.CalculateYearlyWage(_inputSalary);
    }

    private WageResult _actualSalary;
    private readonly Money _inputSalary;
    private readonly Money _expectedSalary;

    public WhenCalculatingFromAYearlyIncome(double inputSalary, double expectedSalary)
    {
        _inputSalary = Money.From((decimal)inputSalary);
        _expectedSalary = Money.From((decimal)expectedSalary);
    }

    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}