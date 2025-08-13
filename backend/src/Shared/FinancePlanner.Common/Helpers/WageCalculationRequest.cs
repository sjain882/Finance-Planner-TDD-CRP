using FinancePlanner.Common.Values;

namespace FinancePlanner.Common.Models;

public class WageCalculationRequest
{
    public decimal Salary { get; set; }

    public SalaryFrequency SalaryFrequency { get; set; }

    public decimal TaxFreeAmount { get; set; }
}