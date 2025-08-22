namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class WageResponse
{
    public DateTime DatePaid { get; set; }
    
    public int UserID { get; set; }

    public decimal Value { get; set; }
}