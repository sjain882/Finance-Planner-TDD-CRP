using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.Shared.Common.Values;
using FinancePlanner.Core.WageCalculator.Handlers;

namespace FinancePlanner.Core.WageCalculators;

public class WageCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public WageCalculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }
    public void Calculate(WageCalculationRequest wageCalculationRequest)
    {
        // AbstractHandler handler = new FromYearlySalary();
        IWageCalculator wageCalculator = wageCalculationRequest.SalaryFrequency switch
        {
            SalaryFrequency.Yearly => new FromYearlySalary(),
            SalaryFrequency.Monthly => new FromMonthlySalary(),
            SalaryFrequency.Weekly => new FromWeeklySalary(_dateTimeProvider),
            SalaryFrequency.Daily => new FromDailySalary(_dateTimeProvider),
            _ => throw new NotImplementedException(),
        };
        wageCalculator = new GetTaxableIncome(wageCalculator, wageCalculationRequest.TaxFreeAmount);

        var x = wageCalculator.CalculateYearlyWage(wageCalculationRequest.Salary);
        
        Console.WriteLine(x.YearlySalary);
        Console.WriteLine(x.TaxableAmount);
    }
}