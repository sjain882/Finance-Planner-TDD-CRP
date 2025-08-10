using System.Globalization;
using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculator.Handlers;

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
            YearlySalary = salary * weeksInCurrentYear,
        };
    }
}