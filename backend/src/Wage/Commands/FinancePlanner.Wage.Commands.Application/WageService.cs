using FinancePlanner.Wage.Commands.Domain.Contracts.Request;
using FinancePlanner.Wage.Commands.Domain.Handlers;
using FinancePlanner.Wage.Commands.Repository;

namespace FinancePlanner.Wage.Commands.Application;

public class WageService : IWageService
{
    private readonly IWageRepository _wageRepository;

    public WageService(IWageRepository wageRepository)
    {
        _wageRepository = wageRepository;
    }

    public void AddWage(AddWageRequest addWageRequest)
    {
        _wageRepository.AddWage(addWageRequest);
    }
}