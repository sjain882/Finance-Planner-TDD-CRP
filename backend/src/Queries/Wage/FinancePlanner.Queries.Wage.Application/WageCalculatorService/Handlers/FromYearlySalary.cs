using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;

public class FromYearlySalary : IWageCalculator
{
    public WageResult CalculateYearlyWage(Money salary)
    {
        return new WageResult
        {
            YearlySalary = salary
        };
    }
}