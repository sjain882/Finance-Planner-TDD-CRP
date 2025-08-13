using FinancePlanner.Common.Models;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Wage.Application;

namespace FinancePlanner.Main;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new WageCalculator(new DateTimeProvider());

        calculator.Calculate(new WageCalculationRequest
        {
            Salary = 500m,
            SalaryFrequency = SalaryFrequency.Weekly,
            TaxFreeAmount = 200m
        });
    }
}