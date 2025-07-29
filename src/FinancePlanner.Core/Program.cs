using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.Shared.Common.Values;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new Calculator(new DateTimeProvider());
        
        calculator.Calculate(new HandlerRequest()
        {
            Salary = 500m,
            SalaryFrequency = SalaryFrequency.Weekly,
            TaxFreeAmount = 200m,
        });
    }
}