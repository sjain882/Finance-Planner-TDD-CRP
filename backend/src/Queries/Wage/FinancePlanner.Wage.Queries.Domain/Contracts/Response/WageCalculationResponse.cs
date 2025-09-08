using FinancePlanner.Common.Utilities.Payment;

namespace FinancePlanner.Wage.Queries.Domain.Contracts.Response;

public class WageCalculationResponse
{
    public decimal GrossYearlyIncome { get; set; }
    public List<RepeatedPaymentResponse> Wage { get; set; } = Enumerable.Empty<RepeatedPaymentResponse>().ToList();
}