using FinancePlanner.Common.Models;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Utilities.Payment;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Queries.Wage.Domain.Handlers;

namespace FinancePlanner.Queries.Wage.Application;

public class WageCalculator : IWageService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public WageCalculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public WageResponse CalculateWage(WageCalculationRequest calculationRequest)
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

        var yearlyIncome = wageResult.YearlySalary - wageResult.TaxedAmount;

        var monthlyIncome = yearlyIncome / 12;
        
        var repeatedPayments = new List<RepeatedPayment>()
        {
            new RepeatedPayment(monthlyIncome, 12)
        };
        
        return new WageResponse()
        {
            GrossYearlyIncome = wageResult.YearlySalary,
            Wage = repeatedPayments
        };

        // Console.WriteLine(wageResult.YearlySalary);
        // Console.WriteLine(wageResult.TaxableAmount);
    }
}