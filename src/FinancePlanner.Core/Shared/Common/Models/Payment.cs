namespace FinancePlanner.Core.Shared.Common.Models;

public class Payment(decimal value, int numberOfPayments)
{
    public decimal Value { get; } = value;
    public int NumberOfPayments { get; } = numberOfPayments;
}