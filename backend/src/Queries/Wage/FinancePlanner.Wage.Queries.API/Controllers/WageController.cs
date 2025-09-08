using FinancePlanner.Common.Utilities.MoneyUtil;
using FinancePlanner.Common.Utilities.Result;
using FinancePlanner.Common.Values;
using FinancePlanner.Shared.Queries.Common.Helpers;
using FinancePlanner.Wage.Queries.Domain.Contracts.Request;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;
using FinancePlanner.Wage.Queries.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FinancePlanner.Wage.Queries.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WageController : ControllerBase
{
    private readonly IWageService _wageService;

    public WageController(IWageService wageService)
    {
        _wageService = wageService;
    }

    [HttpPost]
    [Route("calculate")]
    public IActionResult CalculateWage(WageCalculationRequest wageCalculationRequest)
    {
        var salaryFrequencySuccess =
            Enum.TryParse<SalaryFrequency>(wageCalculationRequest.SalaryFrequency, true, out var salaryFrequency);

        if (salaryFrequencySuccess)
            return ControllerHelper.Convert(_wageService.CalculateWage(
                new Common.Helpers.WageCalculationRequest
                {
                    Salary = Money.From(wageCalculationRequest.Salary),
                    SalaryFrequency = salaryFrequency,
                    TaxFreeAmount = Money.From(wageCalculationRequest.TaxFreeAmount),
                    PersonalAllowance = Money.From(wageCalculationRequest.PersonalAllowance)
                }));

        return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(
            ErrorCode.InvalidSalaryFrequency,
            ErrorDescription.InvalidSalaryFrequency)));
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllWages()
    {
        return ControllerHelper.Convert(await _wageService.GetAllWages());

        return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(
            ErrorCode.InvalidSalaryFrequency,
            ErrorDescription.InvalidSalaryFrequency)));
    }

    [HttpGet]
    [Route("all/raw/{userid:int}")]
    public async Task<IActionResult> GetAllWagesByUser(int userid)
    {
        return ControllerHelper.Convert(await _wageService.GetAllWages(userid));

        return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(
            ErrorCode.InvalidSalaryFrequency,
            ErrorDescription.InvalidSalaryFrequency)));
    }

    [HttpPost]
    [Route("all/{userid:int}")]
    public async Task<IActionResult> GetEmployeeWage(
        int userid,
        [FromQuery] decimal personalAllowance,
        [FromQuery] decimal taxFreeAmount)
    {
        var result = await _wageService.GetEmployeeWage(userid, personalAllowance, taxFreeAmount);

        return ControllerHelper.Convert(result);

        return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(
            ErrorCode.InvalidSalaryFrequency,
            ErrorDescription.InvalidSalaryFrequency)));
    }
}