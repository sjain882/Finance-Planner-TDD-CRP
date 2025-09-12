using FinancePlanner.Shared.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService;

public class WageResult
{
    public Money YearlySalary { get; set; }
    public Money TaxableAmount { get; set; }
    public Money TaxedAmount { get; set; }
}