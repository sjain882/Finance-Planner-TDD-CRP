using FinancePlanner.Shared.Common.Helpers;
using FinancePlanner.Shared.Common.Utilities.Result;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService;

public interface IWageCalculatorService
{
    public ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest calculationRequest);
}