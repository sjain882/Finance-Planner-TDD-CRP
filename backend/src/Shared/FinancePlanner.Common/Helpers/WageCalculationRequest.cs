using FinancePlanner.Common.Values;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Common.Models;

public class WageCalculationRequest
{
    public Money Salary { get; set; }

    public SalaryFrequency SalaryFrequency { get; set; }

    public Money TaxFreeAmount { get; set; }
}