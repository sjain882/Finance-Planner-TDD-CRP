using FinancePlanner.Wage.Commands.Domain.Contracts.Request;

namespace FinancePlanner.Wage.Commands.Repository;

public interface IWageRepository
{
    public Task AddWage(AddWageRequest addWageRequest);
}