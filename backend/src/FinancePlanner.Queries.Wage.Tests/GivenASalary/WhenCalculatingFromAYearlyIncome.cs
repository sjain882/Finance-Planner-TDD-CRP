using FinancePlanner.Queries.Wage.Application;

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
    private readonly decimal _inputSalary;
    private readonly decimal _expectedSalary;

    public WhenCalculatingFromAYearlyIncome(double inputSalary, double expectedSalary)
    {
        _inputSalary = (decimal)inputSalary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}