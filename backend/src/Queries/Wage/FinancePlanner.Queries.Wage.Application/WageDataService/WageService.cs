using FinancePlanner.Queries.Wage.Repository;
using FinancePlanner.Common.Helpers;
using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Wage.Application.WageCalculatorService;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Queries.Wage.Domain.Handlers;
using FinancePlanner.Shared.Common.Result;
using MoneyTracker.Common.Utilities.MoneyUtil;

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

    public async Task<ResultT<List<DayWageResponse>>> GetAllWages()
    {
        return await _wageRepository.GetAllWages();
    }
    
    public async Task<ResultT<WageCalculationResponse>> GetEmployeeWage(int userid, decimal personalAllowance, decimal taxFreeAmount)
    {
        var allDailyWages = await _wageRepository.GetEmployeeWage(userid);
        
        if (!allDailyWages.IsSuccess)
        {
            return allDailyWages.Error!;
        }

        var salaryBeforeTax = Money.From(allDailyWages.Value.Sum(y => y.Value));
        
        var request = new WageCalculationRequest()
        {
            PersonalAllowance = Money.From(personalAllowance),
            Salary = salaryBeforeTax,
            SalaryFrequency = SalaryFrequency.Yearly,
            TaxFreeAmount = Money.From(taxFreeAmount)
        };
            
        return _wageCalculatorService.CalculateWage(request);
    }
}