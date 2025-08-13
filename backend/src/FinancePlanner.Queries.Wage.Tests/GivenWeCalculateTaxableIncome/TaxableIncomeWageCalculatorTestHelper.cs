using FinancePlanner.Queries.Wage.Application;

namespace FinancePlanner.Queries.Wage.Tests.GivenWeCalculateTaxableIncome;

public class TaxableIncomeWageCalculatorTestHelper : IWageCalculator
{
    public WageResult CalculateYearlyWage(decimal salary)
    {
        return new WageResult
        {
            YearlySalary = salary
        };
    }
}