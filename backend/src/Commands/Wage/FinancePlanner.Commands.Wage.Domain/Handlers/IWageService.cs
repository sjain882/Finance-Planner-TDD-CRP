using FinancePlanner.Commands.Wage.Domain.Contracts.Request;

namespace FinancePlanner.Commands.Wage.Domain.Handlers;

public interface IWageService
{
    public void AddWage(AddWageRequest addWageRequest);
}