using FinancePlanner.Common.Utilities.Payment;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class WageResponse
{
    public Money GrossYearlyIncome { get; set; }
    public List<RepeatedPayment> Wage { get; set; }
}