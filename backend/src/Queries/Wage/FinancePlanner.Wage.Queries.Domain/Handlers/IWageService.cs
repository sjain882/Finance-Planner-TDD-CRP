using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.Result;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;

namespace FinancePlanner.Wage.Queries.Domain.Handlers;

public interface IWageService
{
    ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest request);

    Task<ResultT<List<DayWageResponse>>> GetAllWages();
    
    Task<ResultT<List<DayWageResponse>>> GetAllWages(int userid);
    
    Task<ResultT<WageCalculationResponse>> GetEmployeeWage(int userid, decimal personalAllowance, decimal taxFreeAmount);
}