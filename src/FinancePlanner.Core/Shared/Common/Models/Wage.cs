namespace FinancePlanner.Core.Shared.Common.Models;

public class Wage(List<Payment> payments)
{
    public List<Payment> Payments { get; } = payments;
}