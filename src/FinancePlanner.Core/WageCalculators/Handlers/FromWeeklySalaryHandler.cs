using System.Globalization;
using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class FromWeeklySalaryHandler : IHandler
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FromWeeklySalaryHandler(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }
    
    public HandlerResult Handle(decimal salary)
    {
        var weeksInCurrentYear = ISOWeek.GetWeeksInYear(_dateTimeProvider.Now.Year);

        return new HandlerResult
        {
            YearlySalary = salary * weeksInCurrentYear,
        };
    }
}