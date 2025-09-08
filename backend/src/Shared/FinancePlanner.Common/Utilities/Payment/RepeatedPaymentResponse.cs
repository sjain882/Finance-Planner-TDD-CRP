using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Common.Utilities.Payment;

public class RepeatedPaymentResponse(decimal value, int numberOfPayments)
{
    public decimal Value { get; } = value;
    public int NumberOfPayments { get; } = numberOfPayments;
}