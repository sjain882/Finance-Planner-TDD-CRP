using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Common.Helpers;
using FinancePlanner.Queries.Wage.Domain.Contracts.Request;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Queries.Wage.Domain.Handlers;
using FinancePlanner.Shared.Common.Result;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Queries.Wage.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WageController : ControllerBase
{
    private readonly IWageService _wageService;

    public WageController(IWageService wageService)
    {
        _wageService = wageService;
    }

    [HttpPost(Name = "calculate")]
    public IActionResult CalculateWage(WageCalculationRequest wageCalculationRequest)
    {
        var salaryFrequencySuccess =
            Enum.TryParse<SalaryFrequency>(wageCalculationRequest.SalaryFrequency, out var salaryFrequency);

        if (salaryFrequencySuccess)
            return ControllerHelper.Convert(_wageService.CalculateWage(
                new FinancePlanner.Common.Helpers.WageCalculationRequest
                {
                    Salary = Money.From(wageCalculationRequest.Salary),
                    SalaryFrequency = salaryFrequency,
                    TaxFreeAmount = Money.From(wageCalculationRequest.TaxFreeAmount),
                    PersonalAllowance = Money.From(wageCalculationRequest.PersonalAllowance)
                }));

        return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(ErrorCode.InvalidSalaryFrequency,
            ErrorDescription.InvalidSalaryFrequency)));
    }
    
    [HttpGet(Name = "getallwages")]
    public async Task<IActionResult> GetAllWages()
    {
        return ControllerHelper.Convert(await _wageService.GetAllWages());

        return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(ErrorCode.InvalidSalaryFrequency,
            ErrorDescription.InvalidSalaryFrequency)));
    }
}