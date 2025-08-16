namespace FinancePlanner.Common.Utilities.Payment;

public class RepeatedPayment(decimal value, int numberOfPayments)
{
    public decimal Value { get; } = value;
    public int NumberOfPayments { get; } = numberOfPayments;
}