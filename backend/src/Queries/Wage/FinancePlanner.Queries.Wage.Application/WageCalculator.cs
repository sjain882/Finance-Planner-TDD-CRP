using FinancePlanner.Common.Models;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Values;

namespace FinancePlanner.Queries.Wage.Application;

public class WageCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public WageCalculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public void Calculate(WageCalculationRequest calculationRequest)
    {
        // AbstractHandler handler = new FromYearlySalary();
        IWageCalculator wageCalculator = calculationRequest.SalaryFrequency switch
        {
            SalaryFrequency.Yearly => new FromYearlySalary(),
            SalaryFrequency.Monthly => new FromMonthlySalary(),
            SalaryFrequency.Weekly => new FromWeeklySalary(_dateTimeProvider),
            SalaryFrequency.Daily => new FromDailySalary(_dateTimeProvider),
            _ => throw new NotImplementedException()
        };
        wageCalculator = new GetTaxableIncome(wageCalculator, calculationRequest.TaxFreeAmount);

        var wageResult = wageCalculator.CalculateYearlyWage(calculationRequest.Salary);

        Console.WriteLine(wageResult.YearlySalary);
        Console.WriteLine(wageResult.TaxableAmount);
    }
}