namespace FinancePlanner.Queries.Wage.API.Public;

public class WageCalculationRequest
{
    public decimal Salary { get; set; }
    
    public string SalaryFrequency { get; set; }
    
    public decimal TaxFreeAmount { get; set; }
}