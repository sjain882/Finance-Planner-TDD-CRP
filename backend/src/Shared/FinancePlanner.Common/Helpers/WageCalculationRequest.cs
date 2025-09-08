using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Common.Values;

namespace FinancePlanner.Common.Helpers;

public class WageCalculationRequest
{
    public Money Salary { get; set; }

    public SalaryFrequency SalaryFrequency { get; set; }

    public Money TaxFreeAmount { get; set; }

    public Money PersonalAllowance { get; set; }
}