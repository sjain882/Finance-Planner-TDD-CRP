namespace FinancePlanner.Queries.Wage.Application;

public class FromMonthlySalary : IWageCalculator
{
    public WageResult CalculateYearlyWage(decimal salary)
    {
        return new WageResult
        {
            YearlySalary = salary * 12
        };
    }
}