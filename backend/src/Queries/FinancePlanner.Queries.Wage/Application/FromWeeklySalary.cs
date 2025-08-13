using System.Globalization;
using FinancePlanner.Common.Utilities.DateTimeUtil;

namespace FinancePlanner.Queries.Wage.Application;

public class FromWeeklySalary : IWageCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FromWeeklySalary(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public WageResult CalculateYearlyWage(decimal salary)
    {
        var weeksInCurrentYear = ISOWeek.GetWeeksInYear(_dateTimeProvider.Now.Year);

        return new WageResult
        {
            YearlySalary = salary * weeksInCurrentYear
        };
    }
}