using FinancePlanner.Core.Shared.Common.Interfaces;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.WageCalculators.Handlers.TaxCode;

public class CalculateTaxCodeLHandler : IHandler
{
    private readonly IHandler _handler;
    private readonly decimal _personalAllowance;

    public CalculateTaxCodeLHandler(IHandler handler, decimal personalAllowance)
    {
        _handler = handler;
        _personalAllowance = personalAllowance;
    }

    public HandlerResult Handle(decimal salary)
    {
        var result =  _handler.Handle(salary);

        decimal taxableAmount = 0;
        
        // Personal allowance only under 123700
        if (result.YearlySalary < 123700)
        {
            taxableAmount = result.YearlySalary - _personalAllowance;
        }

        // If income level is below all tax thresholds
        if (taxableAmount <= 0)
        {
            return result;
        }
        
        decimal remaining = taxableAmount;

        // Basic rate – 20% on income from £12,571 to £50,270
        decimal basicRateLimit = 50270 - _personalAllowance;
        if (remaining > 0)
        {
            decimal basicRateTaxable = Math.Min(remaining, basicRateLimit);
            result.TaxedAmount += basicRateTaxable * 0.20m;
            remaining -= basicRateTaxable;
        }

        // Higher rate – 40% on income from £50,271 to £125,140
        decimal higherRateLimit = 125140 - 50270;
        if (remaining > 0)
        {
            decimal higherRateTaxable = Math.Min(remaining, higherRateLimit);
            result.TaxedAmount += higherRateTaxable * 0.40m;
            remaining -= higherRateTaxable;
        }

        // Additional rate – 45% on income above £125,140
        if (remaining > 0)
        {
            result.TaxedAmount += remaining * 0.45m;
        }

        return result;
    }
}