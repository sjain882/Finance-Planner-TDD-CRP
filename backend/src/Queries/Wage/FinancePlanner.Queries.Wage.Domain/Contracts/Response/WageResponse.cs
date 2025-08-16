using FinancePlanner.Common.Utilities.Payment;

namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class WageResponse
{
    public decimal GrossYearlyIncome { get; set; }
    public List<RepeatedPayment> Wage { get; set; }
}