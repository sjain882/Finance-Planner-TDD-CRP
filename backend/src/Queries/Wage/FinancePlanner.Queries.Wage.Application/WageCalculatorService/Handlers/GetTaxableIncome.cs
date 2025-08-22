using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;

public class GetTaxableIncome : IWageCalculator
{
    private readonly IWageCalculator _next;
    private readonly Money _yearlyTaxFreeAmount;

    public GetTaxableIncome(IWageCalculator next, Money yearlyTaxFreeAmount)
    {
        _next = next;
        _yearlyTaxFreeAmount = yearlyTaxFreeAmount;
    }

    public WageResult CalculateYearlyWage(Money salary)
    {
        var handlerResult = _next.CalculateYearlyWage(salary);
        handlerResult.TaxableAmount = handlerResult.YearlySalary - _yearlyTaxFreeAmount;

        return handlerResult;
    }
}