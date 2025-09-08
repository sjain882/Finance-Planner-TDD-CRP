using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Wage.Queries.Application;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;

namespace FinancePlanner.Wage.Queries.Tests.GivenASalary;

// Injects into setup instead of method for class wide test
[TestFixture(1, 12)]
[TestFixture(1500, 18000)]
public class WhenCalculatingFromAMonthlyIncome
{
    [SetUp]
    public void Setup()
    {
        var sut = new FromMonthlySalary();
        _actualSalary = sut.CalculateYearlyWage(_salary);
    }

    private WageResult _actualSalary;
    private readonly Money _salary;
    private readonly Money _expectedSalary;

    public WhenCalculatingFromAMonthlyIncome(double salary, double expectedSalary)
    {
        _salary = Money.From((decimal)salary);
        _expectedSalary = Money.From((decimal)expectedSalary);
    }

    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}