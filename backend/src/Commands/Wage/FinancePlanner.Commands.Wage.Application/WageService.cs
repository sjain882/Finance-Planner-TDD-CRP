using FinancePlanner.Commands.Wage.Domain.Contracts.Request;
using FinancePlanner.Commands.Wage.Domain.Handlers;
using FinancePlanner.Commands.Wage.Repository;

namespace FinancePlanner.Commands.Wage.Application;

public class WageService: IWageService
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