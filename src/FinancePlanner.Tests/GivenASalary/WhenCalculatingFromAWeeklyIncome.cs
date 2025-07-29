using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.WageCalculator.Handlers;
using FinancePlanner.Core.WageCalculators;
using Moq;

namespace FinancePlanner.Tests.GivenYearlySalary;

// Injects into setup instead of method for class wide test
[TestFixture(500, 2025, 07, 29, 26000)]
[TestFixture(500, 2024, 07, 29, 26000)]
[TestFixture(384.62, 2024, 07, 29, 20000.24)]
public class WhenCalculatingFromAWeeklyIncome
{
    private HandlerResult _actualSalary;
    private readonly decimal _salary;
    private readonly decimal _expectedSalary;
    private readonly DateTime _date;

    public WhenCalculatingFromAWeeklyIncome(double salary, int year, int month, int day, double expectedSalary)
    {
        _date = new DateTime(year, month, day);
        _salary = (decimal)salary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [SetUp]
    public void Setup()
    {
        var dateTimeMock = new Mock<IDateTimeProvider>();
        dateTimeMock
            .Setup(x => x.Now)
            .Returns(_date);
        var sut = new FromWeeklySalaryHandler(dateTimeMock.Object);
        _actualSalary = sut.Handle(_salary);
    }
    
    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}