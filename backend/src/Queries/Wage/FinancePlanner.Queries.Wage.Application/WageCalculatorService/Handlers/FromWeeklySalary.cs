using System.Globalization;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;

public class FromWeeklySalary : IWageCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FromWeeklySalary(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public WageResult CalculateYearlyWage(Money salary)
    {
        var weeksInCurrentYear = ISOWeek.GetWeeksInYear(_dateTimeProvider.Now.Year);

        return new WageResult
        {
            YearlySalary = salary * weeksInCurrentYear
        };
    }
}