using FinancePlanner.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Common.Utilities.Payment;

public class RepeatedPayment(Money value, int numberOfPayments)
{
    public Money Value { get; } = value;
    public int NumberOfPayments { get; } = numberOfPayments;
}