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
    public void Calculate(HandlerRequest handlerRequest)
    {
        // AbstractHandler handler = new FromYearlySalary();
        IHandler handler = handlerRequest.SalaryFrequency switch
        {
            SalaryFrequency.Yearly => new FromYearlySalaryHandler(),
            SalaryFrequency.Monthly => new FromMonthlySalaryHandler(),
            SalaryFrequency.Weekly => new FromWeeklySalaryHandler(_dateTimeProvider),
            _ => throw new NotImplementedException(),
        };
        handler = new GetTaxableIncomeHandler(handler, handlerRequest.TaxFreeAmount);

        var x = handler.Handle(handlerRequest.Salary);
        
        Console.WriteLine(x.YearlySalary);
        Console.WriteLine(x.TaxableAmount);
    }
}