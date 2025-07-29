using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class FromMonthlySalaryHandler : IHandler
{
    public HandlerResult Handle(decimal salary)
    {
        return new HandlerResult
        {
            YearlySalary = salary * 12,
        };
    }
}