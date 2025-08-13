using FinancePlanner.Core.Shared.Common.Values;

namespace FinancePlanner.Core.Shared.Common.Models;

public class WageCalculationRequest
{
    public decimal Salary { get; set; }

    public SalaryFrequency SalaryFrequency { get; set; }

    public decimal TaxFreeAmount { get; set; }
}