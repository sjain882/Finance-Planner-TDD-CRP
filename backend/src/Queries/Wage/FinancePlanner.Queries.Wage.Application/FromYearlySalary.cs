namespace FinancePlanner.Queries.Wage.Application;

public class FromYearlySalary : IWageCalculator
{
    public WageResult CalculateYearlyWage(decimal salary)
    {
        return new WageResult
        {
            YearlySalary = salary
        };
    }
}