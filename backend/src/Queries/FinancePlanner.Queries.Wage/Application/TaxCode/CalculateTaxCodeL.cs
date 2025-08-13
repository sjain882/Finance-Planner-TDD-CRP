namespace FinancePlanner.Queries.Wage.Application.TaxCode;

public class CalculateTaxCodeL : IWageCalculator
{
    private readonly decimal _personalAllowance;
    private readonly IWageCalculator _wageCalculator;

    public CalculateTaxCodeL(IWageCalculator wageCalculator, decimal personalAllowance)
    {
        _wageCalculator = wageCalculator;
        _personalAllowance = personalAllowance;
    }

    public WageResult CalculateYearlyWage(decimal salary)
    {
        var result = _wageCalculator.CalculateYearlyWage(salary);

        // PA goes down by £1 for every £2 if salary > £100,000
        var personalAllowance = _personalAllowance;
        if (salary > 100000)
        {
            var reduction = (salary - 100000) / 2;
            personalAllowance = Math.Max(0, _personalAllowance - reduction);
        }

        // Calculate taxable income
        var taxableIncome = Math.Max(0, salary - personalAllowance);

        if (taxableIncome <= 0)
            return result;

        decimal taxPaid = 0;

        // Basic rate – 20% on income from £12,571 to £50,270
        if (salary > 12570)
        {
            var basicTaxable = Math.Min(50270, salary) - 12570;
            taxPaid += basicTaxable * 0.20m;
        }

        // Higher rate – 40% on income from £50,271 to £125,140
        if (salary > 50270)
        {
            var higherTaxable = Math.Min(125140, salary) - 50270;
            taxPaid += higherTaxable * 0.40m;
        }

        // Additional rate – 45% on income above £125,140
        if (salary > 125140)
        {
            var additionalTaxable = salary - 125140;
            taxPaid += additionalTaxable * 0.45m;
        }

        result.TaxedAmount = taxPaid;
        return result;
    }
}