
using FinancePlanner.Common.Models;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;

namespace FinancePlanner.Queries.Wage.Domain.Handlers;

public interface IWageService
{
    WageResponse CalculateWage(WageCalculationRequest request);
}