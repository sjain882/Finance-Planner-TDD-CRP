using FinancePlanner.Shared.Common.Utilities.Result;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;

namespace FinancePlanner.Wage.Queries.Repository;

public interface IWageRepository
{
    public Task<ResultT<List<DayWageResponse>>> GetAllWages();
    public Task<ResultT<List<DayWageResponse>>> GetAllWages(int userid);
    public Task<ResultT<List<DayWageResponse>>> GetEmployeeWage(int userid);
}