using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application;

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