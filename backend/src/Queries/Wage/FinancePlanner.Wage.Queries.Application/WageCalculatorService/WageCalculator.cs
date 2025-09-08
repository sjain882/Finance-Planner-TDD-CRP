using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Utilities.Payment;
using FinancePlanner.Common.Utilities.Result;
using FinancePlanner.Common.Values;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers.TaxCode;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService;

public class WageCalculator : IWageCalculatorService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public WageCalculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest calculationRequest)
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

        var yearlyIncome = (wageResult.YearlySalary - wageResult.TaxedAmount).Amount;

        var firstMonth = Math.Round(yearlyIncome / 12, 2);

        var firstElevenMonths = firstMonth * 11;

        var finalMonth = yearlyIncome - firstElevenMonths;

        List<RepeatedPaymentResponse> repeatedPayments;

        // This needs to be tested manually!
        if (finalMonth == firstMonth)
            repeatedPayments = new List<RepeatedPaymentResponse>
            {
                new(firstMonth, 12)
            };
        else
            repeatedPayments = new List<RepeatedPaymentResponse>
            {
                new(firstElevenMonths, 11),
                new(finalMonth, 1)
            };

        return new WageCalculationResponse
        {
            GrossYearlyIncome = wageResult.YearlySalary.Amount,
            Wage = repeatedPayments
        };

        // Console.WriteLine(wageResult.YearlySalary);
        // Console.WriteLine(wageResult.TaxableAmount);
    }
}