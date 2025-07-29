using System.IO.Enumeration;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculator.Handlers;

namespace FinancePlanner.Tests.GivenYearlySalary;

// Injects into setup instead of method for class wide test
[TestFixture(500, 26000)]           // this doesn't account for leap years properly - see next commit
public class WhenCalculatingFromAWeeklyIncome
{
    private HandlerResult _actualSalary;
    private readonly decimal _salary;
    private readonly decimal _expectedSalary;

    public WhenCalculatingFromAWeeklyIncome(double salary, double expectedSalary)
    {
        _salary = (decimal)salary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [SetUp]
    public void Setup()
    {
        var sut = new FromWeeklySalaryHandler();
        _actualSalary = sut.Handle(_salary);
    }
    
    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}