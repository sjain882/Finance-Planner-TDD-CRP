using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Core.Shared.Common.Values;
using FinancePlanner.Core.WageCalculator.Handlers;

namespace FinancePlanner.Core.WageCalculators;

public class Calculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public Calculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }
    public void Calculate(CalculateWageRequest calculateWageRequest)
    {
        // AbstractHandler handler = new FromYearlySalary();
        IHandler handler = calculateWageRequest.SalaryFrequency switch
        {
            SalaryFrequency.Yearly => new FromYearlySalaryHandler(),
            SalaryFrequency.Monthly => new FromMonthlySalaryHandler(),
            SalaryFrequency.Weekly => new FromWeeklySalaryHandler(_dateTimeProvider),
            _ => throw new NotImplementedException(),
        };
        handler = new GetTaxableIncomeHandler(handler, calculateWageRequest.TaxFreeAmount);

        var x = handler.Handle(calculateWageRequest.Salary);
        
        Console.WriteLine(x.YearlySalary);
        Console.WriteLine(x.TaxableAmount);
    }
}