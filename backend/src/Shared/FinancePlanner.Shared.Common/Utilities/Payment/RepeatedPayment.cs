using FinancePlanner.Shared.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Shared.Common.Utilities.Payment;

public class RepeatedPayment(Money value, int numberOfPayments)
{
    public Money Value { get; } = value;
    public int NumberOfPayments { get; } = numberOfPayments;
}