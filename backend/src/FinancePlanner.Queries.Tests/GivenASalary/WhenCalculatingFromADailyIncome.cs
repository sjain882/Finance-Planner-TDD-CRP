using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Queries.Wage.Application;
using Moq;

namespace FinancePlanner.Queries.Tests.GivenASalary;

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
    private readonly decimal _salary;
    private readonly decimal _expectedSalary;
    private readonly DateTime _date;

    public WhenCalculatingFromADailyIncome(double salary, int year, int month, int day, double expectedSalary)
    {
        _date = new DateTime(year, month, day);
        _salary = (decimal)salary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}