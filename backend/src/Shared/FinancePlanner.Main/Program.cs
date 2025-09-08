using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Common.Values;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;

namespace FinancePlanner.Main;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new WageCalculator(new DateTimeProvider());

        calculator.CalculateWage(new WageCalculationRequest
        {
            Salary = Money.From(500m),
            SalaryFrequency = SalaryFrequency.Weekly,
            TaxFreeAmount = Money.From(200m)
        });
    }
}