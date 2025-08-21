namespace FinancePlanner.Commands.Wage.Domain.Contracts.Request;

public class AddWageRequest
{
    public int UserID { get; set; }
    
    public decimal Value { get; set; }
    
    public DateTime DatePaid { get; set; }
    
}