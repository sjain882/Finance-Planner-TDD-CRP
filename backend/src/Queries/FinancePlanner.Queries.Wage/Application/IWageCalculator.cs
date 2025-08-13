namespace FinancePlanner.Queries.Wage.Application;

// Handler interface in CRP
public interface IWageCalculator
{
    WageResult CalculateYearlyWage(decimal salary);
}