using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.Shared.Common.Interfaces;

// Handler interface in CRP
public interface IWageCalculator
{
    WageResult CalculateYearlyWage(decimal salary);
}