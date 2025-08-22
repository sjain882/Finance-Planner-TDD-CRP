using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Queries.Wage.Application;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;
using MoneyTracker.Common.Utilities.MoneyUtil;
using Moq;

namespace FinancePlanner.Queries.Wage.Tests.GivenASalary;

// Injects into setup instead of method for class wide test
[TestFixture(70, 2025, 07, 29, 25550)]
[TestFixture(70, 2028, 07, 29, 25620)]
public class WhenCalculatingFromADailyIncome
{
    [SetUp]
    public void Setup()
    {
        var dateTimeMock = new Mock<IDateTimeProvider>();
        dateTimeMock
            .Setup(x => x.Now)
            .Returns(_date);
        var sut = new FromDailySalary(dateTimeMock.Object);
        _actualSalary = sut.CalculateYearlyWage(_salary);
    }

    private WageResult _actualSalary;
    private readonly Money _salary;
    private readonly Money _expectedSalary;
    private readonly DateTime _date;

    public WhenCalculatingFromADailyIncome(double salary, int year, int month, int day, double expectedSalary)
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