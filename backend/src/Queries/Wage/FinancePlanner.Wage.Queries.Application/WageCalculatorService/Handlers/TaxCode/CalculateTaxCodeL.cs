using FinancePlanner.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService.Handlers.TaxCode;

public class CalculateTaxCodeL : IWageCalculator
{
    private readonly Money _personalAllowance;
    private readonly IWageCalculator _wageCalculator;

    public CalculateTaxCodeL(IWageCalculator wageCalculator, Money personalAllowance)
    {
        _wageCalculator = wageCalculator;
        _personalAllowance = personalAllowance;
    }

    public WageResult CalculateYearlyWage(Money salary)
    {
        var result = _wageCalculator.CalculateYearlyWage(salary);

        var personalAllowance = _personalAllowance;
        if (salary > Money.From(100000))
        {
            var reduction = (salary - Money.From(100000)) / 2;
            personalAllowance = Money.Max(Money.Zero, _personalAllowance - reduction);
        }

        var taxableIncome = Money.Max(Money.Zero, salary - personalAllowance);

        if (taxableIncome <= 0)
        {
            result.TaxedAmount = Money.Zero;
            return result;
        }

        var taxPaid = Money.Zero;

        if (salary > 12570)
        {
            var basicTaxable = Money.Min(Money.From(50270), salary) - _personalAllowance;
            taxPaid += basicTaxable * 0.20m;
        }

        if (salary > 50270)
        {
            var higherTaxable = Money.Min(Money.From(125140), salary) - Money.From(50270);
            taxPaid += higherTaxable * 0.40m;
        }

        if (salary > 125140)
        {
            var additionalTaxable = salary - Money.From(125140);
            taxPaid += additionalTaxable * 0.45m;
        }

        result.TaxedAmount = taxPaid;
        return result;
    }
}