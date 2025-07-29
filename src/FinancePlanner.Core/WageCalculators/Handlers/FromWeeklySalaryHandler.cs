using System.Globalization;
using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class FromWeeklySalaryHandler : IHandler
{
    public HandlerResult Handle(decimal salary)
    {
        var weeksInCurrentYear = ISOWeek.GetWeeksInYear(System.DateTime.Now.Year);

        return new HandlerResult
        {
            YearlySalary = salary * weeksInCurrentYear,
        };
    }
}