using System.IO.Enumeration;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculator.Handlers;

namespace FinancePlanner.Tests.GivenYearlySalary;

// Injects into setup instead of method for class wide test
[TestFixture(1, 12)]
[TestFixture(1500, 18000)]
public class WhenCalculatingFromAMonthlyIncome
{
    private HandlerResult _actualSalary;
    private readonly decimal _salary;
    private readonly decimal _expectedSalary;

    public WhenCalculatingFromAMonthlyIncome(double salary, double expectedSalary)
    {
        _salary = (decimal)salary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [SetUp]
    public void Setup()
    {
        var sut = new FromMonthlySalaryHandler();
        _actualSalary = sut.Handle(_salary);
    }
    
    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}