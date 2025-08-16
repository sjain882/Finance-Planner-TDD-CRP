using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application;

// Handler interface in CRP
public interface IWageCalculator
{
    WageResult CalculateYearlyWage(Money salary);
}