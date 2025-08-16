using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.API.Public;

public class WageCalculationRequest
{
    public Money Salary { get; set; }
    
    public string SalaryFrequency { get; set; }
    
    public Money TaxFreeAmount { get; set; }
}