using FinancePlanner.Shared.Common.Utilities.MoneyUtil;
using FinancePlanner.Shared.Common.Values;

namespace FinancePlanner.Shared.Common.Helpers;

public class WageCalculationRequest
{
    public Money Salary { get; set; }

    public SalaryFrequency SalaryFrequency { get; set; }

    public Money TaxFreeAmount { get; set; }

    public Money PersonalAllowance { get; set; }
}