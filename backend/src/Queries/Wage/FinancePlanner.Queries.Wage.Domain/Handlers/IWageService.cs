using FinancePlanner.Common.Helpers;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Shared.Common.Result;

namespace FinancePlanner.Queries.Wage.Domain.Handlers;

public interface IWageService
{
    ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest request);

    Task<ResultT<List<DayWageResponse>>> GetAllWages();
    
    Task<ResultT<List<DayWageResponse>>> GetAllWages(int userid);
    
    Task<ResultT<WageCalculationResponse>> GetEmployeeWage(int userid, decimal personalAllowance, decimal taxFreeAmount);
}