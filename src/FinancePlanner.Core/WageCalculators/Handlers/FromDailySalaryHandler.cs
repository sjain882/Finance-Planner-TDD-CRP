using System.Globalization;
using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class FromDailySalaryHandler : IHandler
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FromDailySalaryHandler(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }
    
    public HandlerResult Handle(decimal salary)
    {
        var daysInCurrentYear = DateTime.IsLeapYear(_dateTimeProvider.Now.Year) ? 366 : 365;

        return new HandlerResult
        {
            YearlySalary = salary * daysInCurrentYear,
        };
    }
}