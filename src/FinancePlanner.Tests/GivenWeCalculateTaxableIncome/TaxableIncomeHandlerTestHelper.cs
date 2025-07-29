using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;

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