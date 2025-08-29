namespace FinancePlanner.Queries.Wage.Domain.Contracts.Response;

public class DayWageResponse
{
    // Time doesn't matter here
    public DateTime DatePaid { get; set; }
    
    public int UserID { get; set; }

    public decimal Value { get; set; }
}