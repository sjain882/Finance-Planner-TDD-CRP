using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Values;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core;

public class Program
{
    public static void Main(string[] args)
    {
        Calculator.Calculate(new HandlerRequest()
        {
            Salary = 20000.00m,
            SalaryFrequency = SalaryFrequency.Monthly,
            TaxFreeAmount = 2000.00m,
        });
    }
}