using FinancePlanner.Wage.Commands.Domain.Contracts.Request;

namespace FinancePlanner.Wage.Commands.Domain.Handlers;

public interface IWageService
{
    public void AddWage(AddWageRequest addWageRequest);
}