using FinancePlanner.Common.Models;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Wage.Application;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using FinancePlanner.Queries.Wage.Domain.Handlers;
using FinancePlanner.Shared.Common.Result;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Common.Helpers;
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
    public IActionResult CalculateWage(Public.WageCalculationRequest wageCalculationRequest)
    {
        var salaryFrequencySuccess= Enum.TryParse<SalaryFrequency>(wageCalculationRequest.SalaryFrequency, out var salaryFrequency);

        if (salaryFrequencySuccess)
        {
            return ControllerHelper.Convert(_wageService.CalculateWage(new WageCalculationRequest
            {
                Salary = Money.From(wageCalculationRequest.Salary),
                SalaryFrequency = salaryFrequency,
                TaxFreeAmount = Money.From(wageCalculationRequest.TaxFreeAmount),
                PersonalAllowance = Money.From(wageCalculationRequest.PersonalAllowance)
            }));
        }

        return ControllerHelper.Convert(ResultT<WageResponse>.Failure(Error.Validation(ErrorCode.InvalidSalaryFrequency, ErrorDescription.InvalidSalaryFrequency)));
    }
}