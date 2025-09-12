using FinancePlanner.Shared.Common.Helpers;
using FinancePlanner.Shared.Common.Utilities.MoneyUtil;
using FinancePlanner.Shared.Common.Utilities.Result;
using FinancePlanner.Shared.Common.Values;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;
using FinancePlanner.Wage.Queries.Domain.Handlers;
using FinancePlanner.Wage.Queries.Repository;

namespace FinancePlanner.Wage.Queries.Application.WageDataService;

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

    public async Task<ResultT<List<DayWageResponse>>> GetAllWages()
    {
        return await _wageRepository.GetAllWages();
    }

    public async Task<ResultT<List<DayWageResponse>>> GetAllWages(int userid)
    {
        return await _wageRepository.GetAllWages(userid);
    }

    public async Task<ResultT<WageCalculationResponse>> GetEmployeeWage(int userid, decimal personalAllowance,
        decimal taxFreeAmount)
    {
        var allDailyWages = await _wageRepository.GetEmployeeWage(userid);

        if (!allDailyWages.IsSuccess) return allDailyWages.Error!;

        var salaryBeforeTax = Money.From(allDailyWages.Value.Sum(y => y.Value));

        var request = new WageCalculationRequest
        {
            PersonalAllowance = Money.From(personalAllowance),
            Salary = salaryBeforeTax,
            SalaryFrequency = SalaryFrequency.Yearly,
            TaxFreeAmount = Money.From(taxFreeAmount)
        };

        return _wageCalculatorService.CalculateWage(request);
    }
}