using FinancePlanner.Shared.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;

public class FromMonthlySalary : IWageCalculator
{
    public WageResult CalculateYearlyWage(Money salary)
    {
        return new WageResult
        {
            YearlySalary = salary * 12
        };
    }
}