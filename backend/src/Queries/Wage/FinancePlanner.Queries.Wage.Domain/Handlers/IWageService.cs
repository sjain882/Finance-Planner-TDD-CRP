using FinancePlanner.Common.Helpers;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Shared.Common.Result;

namespace FinancePlanner.Queries.Wage.Domain.Handlers;

public interface IWageService
{
    ResultT<WageResponse> CalculateWage(WageCalculationRequest request);
}