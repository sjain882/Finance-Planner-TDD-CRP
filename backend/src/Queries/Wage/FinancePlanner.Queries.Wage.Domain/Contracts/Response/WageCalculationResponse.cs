using FinancePlanner.Common.Utilities.Payment;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class WageCalculationResponse
{
    public decimal GrossYearlyIncome { get; set; }
    public List<RepeatedPaymentResponse> Wage { get; set; } = Enumerable.Empty<RepeatedPaymentResponse>().ToList();
}