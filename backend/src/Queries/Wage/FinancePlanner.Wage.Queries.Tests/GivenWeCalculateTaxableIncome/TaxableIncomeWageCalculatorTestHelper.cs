using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;

namespace FinancePlanner.Wage.Queries.Tests.GivenWeCalculateTaxableIncome;

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