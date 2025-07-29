using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculators.Handlers.TaxCode;

public class CalculateTaxCodeLHandler : IHandler
{
    private readonly IHandler _handler;
    private readonly decimal _personalAllowance;

    public CalculateTaxCodeLHandler(IHandler handler, decimal personalAllowance)
    {
        _handler = handler;
        _personalAllowance = personalAllowance;
    }

    public HandlerResult Handle(decimal salary)
    {
        return new HandlerResult()
        {
            TaxedAmount = 0,
        };
    }
}