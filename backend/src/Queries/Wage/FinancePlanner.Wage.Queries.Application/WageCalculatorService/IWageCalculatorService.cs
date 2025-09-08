using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.Result;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;

namespace FinancePlanner.Wage.Queries.Application.WageCalculatorService;

public interface IWageCalculatorService
{
    public ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest calculationRequest);
}