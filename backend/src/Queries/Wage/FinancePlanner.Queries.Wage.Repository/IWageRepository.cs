using FinancePlanner.Queries.Wage.Domain.Contracts.Request;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Shared.Common.Result;

namespace FinancePlanner.Queries.Wage.Repository;

public interface IWageRepository
{
    public Task<ResultT<List<WageResponse>>> GetAllWages();
}