using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Tests.GivenWeCalculateTaxableIncome;

public class TaxableIncomeHandlerTestHelper : IHandler
{
    public HandlerResult Handle(decimal salary)
    {
        return new HandlerResult()
        {
            YearlySalary = salary,
        };
    }
}