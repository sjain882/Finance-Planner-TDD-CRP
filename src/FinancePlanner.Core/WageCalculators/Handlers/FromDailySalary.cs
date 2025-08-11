using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class FromDailySalary : IWageCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FromDailySalary(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public WageResult CalculateYearlyWage(decimal salary)
    {
        var daysInCurrentYear = DateTime.IsLeapYear(_dateTimeProvider.Now.Year) ? 366 : 365;

        return new WageResult
        {
            YearlySalary = salary * daysInCurrentYear
        };
    }
}