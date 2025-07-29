using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class FromYearlySalaryHandler : IHandler
{
    public HandlerResult Handle(decimal salary)
    {
        return new HandlerResult
        {
            YearlySalary = salary
        };
    }
}