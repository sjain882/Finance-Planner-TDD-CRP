using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application;

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