using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Shared.Common.Result;

namespace FinancePlanner.Queries.Wage.Repository;

public interface IWageRepository
{
    public Task<ResultT<List<DayWageResponse>>> GetAllWages();
    public Task<ResultT<List<DayWageResponse>>> GetEmployeeWage(int userid);
}