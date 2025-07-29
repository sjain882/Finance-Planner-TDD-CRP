using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class GetTaxableIncomeHandler : IHandler
{
    private readonly IHandler _next;
    private readonly decimal _yearlyTaxFreeAmount;

    public GetTaxableIncomeHandler(IHandler next, decimal yearlyTaxFreeAmount)
    {
        _next = next;
        _yearlyTaxFreeAmount = yearlyTaxFreeAmount;
    }
    
    public HandlerResult Handle(decimal salary)
    {
        var handlerResult = _next.Handle(salary);
        handlerResult.TaxableAmount = handlerResult.YearlySalary - _yearlyTaxFreeAmount;
        
        return handlerResult;
    }
}