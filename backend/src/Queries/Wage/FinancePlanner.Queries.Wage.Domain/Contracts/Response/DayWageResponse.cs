namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class DayWageResponse
{
    public int UserID { get; set; }
    
    public decimal Value { get; set; }
    
    // Time doesn't matter here
    public DateTime DatePaid { get; set; }
}