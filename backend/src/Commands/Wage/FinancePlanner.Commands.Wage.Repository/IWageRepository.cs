using FinancePlanner.Commands.Wage.Domain.Contracts.Request;

namespace FinancePlanner.Commands.Wage.Repository;

public interface IWageRepository
{
    public Task AddWage(AddWageRequest addWageRequest);
}