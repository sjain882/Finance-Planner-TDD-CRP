using FinancePlanner.Common.Utilities.Payment;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class WageCalculationResponse
{
    public Money GrossYearlyIncome { get; set; }
    public List<RepeatedPayment> Wage { get; set; }
}