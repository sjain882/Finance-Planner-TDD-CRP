using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService;

public class WageResult
{
    public Money YearlySalary { get; set; }
    public Money TaxableAmount { get; set; }
    public Money TaxedAmount { get; set; }
}