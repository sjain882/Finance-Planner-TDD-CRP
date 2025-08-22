using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService.Handlers;

// Handler interface in CRP
public interface IWageCalculator
{
    WageResult CalculateYearlyWage(Money salary);
}