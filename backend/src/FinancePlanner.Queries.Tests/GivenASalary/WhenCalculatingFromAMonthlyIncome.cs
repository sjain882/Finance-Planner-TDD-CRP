using FinancePlanner.Queries.Wage.Application;

namespace FinancePlanner.Queries.Tests.GivenASalary;

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
    private readonly decimal _salary;
    private readonly decimal _expectedSalary;

    public WhenCalculatingFromAMonthlyIncome(double salary, double expectedSalary)
    {
        _salary = (decimal)salary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}