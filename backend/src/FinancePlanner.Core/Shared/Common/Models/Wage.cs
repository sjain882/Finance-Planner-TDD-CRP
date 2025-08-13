namespace FinancePlanner.Core.Shared.Common.Models;

public class Wage(List<RepeatedPayment> payments)
{
    public List<RepeatedPayment> Payments { get; } = payments;
}