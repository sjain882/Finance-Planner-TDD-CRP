using FinancePlanner.Queries.Wage.Repository;
using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Queries.Wage.Domain.Handlers;
using FinancePlanner.Shared.Common.Result;

namespace FinancePlanner.Queries.Wage.Application;

public class WageService : IWageService
{
    private readonly IWageCalculatorService _wageCalculatorService;
    private readonly IWageRepository _wageRepository;

    public WageService(IWageCalculatorService wageCalculatorService, IWageRepository wageRepository)
    {
        _wageCalculatorService = wageCalculatorService;
        _wageRepository = wageRepository;
    }

    public ResultT<WageCalculationResponse> CalculateWage(WageCalculationRequest request)
    {
        return _wageCalculatorService.CalculateWage(request);
    }

    public async Task<ResultT<List<WageResponse>>> GetAllWages()
    {
        return await _wageRepository.GetAllWages();
    }
}