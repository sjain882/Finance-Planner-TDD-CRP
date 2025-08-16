using FinancePlanner.Queries.Wage.Application;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Tests.GivenWeCalculateTaxableIncome;

public class TaxableIncomeWageCalculatorTestHelper : IWageCalculator
{
    public WageResult CalculateYearlyWage(Money salary)
    {
        return new WageResult
        {
            YearlySalary = salary
        };
    }
}