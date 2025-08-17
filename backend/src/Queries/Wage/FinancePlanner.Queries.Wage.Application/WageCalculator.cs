using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Utilities.Payment;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Wage.Application.TaxCode;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Queries.Wage.Domain.Handlers;
using FinancePlanner.Shared.Common.Result;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.Application;

public class WageCalculator : IWageService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public WageCalculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public ResultT<WageResponse> CalculateWage(WageCalculationRequest calculationRequest)
    {
        IWageCalculator wageCalculator = calculationRequest.SalaryFrequency switch
        {
            SalaryFrequency.Yearly => new FromYearlySalary(),
            SalaryFrequency.Monthly => new FromMonthlySalary(),
            SalaryFrequency.Weekly => new FromWeeklySalary(_dateTimeProvider),
            SalaryFrequency.Daily => new FromDailySalary(_dateTimeProvider),
            _ => throw new NotImplementedException()
        };
        wageCalculator = new GetTaxableIncome(wageCalculator, calculationRequest.TaxFreeAmount);
        wageCalculator = new CalculateTaxCodeL(wageCalculator, calculationRequest.PersonalAllowance);

        var wageResult = wageCalculator.CalculateYearlyWage(calculationRequest.Salary);

        var yearlyIncome = wageResult.YearlySalary - wageResult.TaxedAmount;
        var monthlyIncome = yearlyIncome / 12;

        var repeatedPayments = new List<RepeatedPayment>
        {
            new(Money.From(monthlyIncome), 12)
        };

        return new WageResponse
        {
            GrossYearlyIncome = wageResult.YearlySalary,
            Wage = repeatedPayments
        };

        // Console.WriteLine(wageResult.YearlySalary);
        // Console.WriteLine(wageResult.TaxableAmount);
    }
}