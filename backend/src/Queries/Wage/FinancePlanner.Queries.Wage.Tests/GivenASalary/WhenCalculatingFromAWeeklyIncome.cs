using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Queries.Wage.Application;
using MoneyTracker.Common.Utilities.MoneyUtil;
using Moq;

namespace FinancePlanner.Queries.Wage.Tests.GivenASalary;

// Injects into setup instead of method for class wide test
[TestFixture(500, 2025, 07, 29, 26000)]
[TestFixture(500, 2024, 07, 29, 26000)]
[TestFixture(384.62, 2024, 07, 29, 20000.24)]
public class WhenCalculatingFromAWeeklyIncome
{
    [SetUp]
    public void Setup()
    {
        var dateTimeMock = new Mock<IDateTimeProvider>();
        dateTimeMock
            .Setup(x => x.Now)
            .Returns(_date);
        var sut = new FromWeeklySalary(dateTimeMock.Object);
        _actualSalary = sut.CalculateYearlyWage(_salary);
    }

    private WageResult _actualSalary;
    private readonly Money _salary;
    private readonly Money _expectedSalary;
    private readonly DateTime _date;

    public WhenCalculatingFromAWeeklyIncome(double salary, int year, int month, int day, double expectedSalary)
    {
        _date = new DateTime(year, month, day);
        _salary = Money.From((decimal)salary);
        _expectedSalary = Money.From((decimal)expectedSalary);
    }

    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}