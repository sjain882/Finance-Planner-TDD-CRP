using FinancePlanner.Common.Helpers;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Shared.Common.Result;

namespace FinancePlanner.Queries.Wage.Application.WageCalculatorService;

public interface IWageCalculatorService
{
    public ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest calculationRequest);
}