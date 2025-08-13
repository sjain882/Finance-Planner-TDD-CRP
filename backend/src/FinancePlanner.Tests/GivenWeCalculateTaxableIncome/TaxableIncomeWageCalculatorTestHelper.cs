using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Tests.GivenWeCalculateTaxableIncome;

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