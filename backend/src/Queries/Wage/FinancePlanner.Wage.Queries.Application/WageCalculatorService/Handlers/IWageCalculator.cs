using FinancePlanner.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;

// Handler interface in CRP
public interface IWageCalculator
{
    WageResult CalculateYearlyWage(Money salary);
}