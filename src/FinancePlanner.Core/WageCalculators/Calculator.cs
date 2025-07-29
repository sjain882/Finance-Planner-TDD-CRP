using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.Shared.Common.Values;
using FinancePlanner.Core.WageCalculator.Handlers;

namespace FinancePlanner.Core.WageCalculators;

public static class Calculator
{
    public static void Calculate(HandlerRequest handlerRequest)
    {
        // AbstractHandler handler = new FromYearlySalary();
        IHandler handler = handlerRequest.SalaryFrequency switch
        {
            SalaryFrequency.Yearly => new FromYearlySalaryHandler(),
            SalaryFrequency.Monthly => new FromMonthlySalaryHandler(),
            _ => throw new NotImplementedException(),
        };
        handler = new GetTaxableIncomeHandler(handler, handlerRequest.TaxFreeAmount);

        var x = handler.Handle(handlerRequest.Salary);
        
        Console.WriteLine(x.YearlySalary);
        Console.WriteLine(x.TaxableAmount);
    }
}