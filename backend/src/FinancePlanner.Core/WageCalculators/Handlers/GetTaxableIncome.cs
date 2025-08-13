using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculator.Handlers;

public class GetTaxableIncome : IWageCalculator
{
    private readonly IWageCalculator _next;
    private readonly decimal _yearlyTaxFreeAmount;

    public GetTaxableIncome(IWageCalculator next, decimal yearlyTaxFreeAmount)
    {
        _next = next;
        _yearlyTaxFreeAmount = yearlyTaxFreeAmount;
    }

    public WageResult CalculateYearlyWage(decimal salary)
    {
        var handlerResult = _next.CalculateYearlyWage(salary);
        handlerResult.TaxableAmount = handlerResult.YearlySalary - _yearlyTaxFreeAmount;

        return handlerResult;
    }
}