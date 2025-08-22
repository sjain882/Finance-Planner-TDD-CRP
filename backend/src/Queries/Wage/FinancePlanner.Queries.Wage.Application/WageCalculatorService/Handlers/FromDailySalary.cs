using FinancePlanner.Common.Utilities.DateTimeUtil;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;

public class FromDailySalary : IWageCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FromDailySalary(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public WageResult CalculateYearlyWage(Money salary)
    {
        var daysInCurrentYear = DateTime.IsLeapYear(_dateTimeProvider.Now.Year) ? 366 : 365;

        return new WageResult
        {
            YearlySalary = salary * daysInCurrentYear
        };
    }
}