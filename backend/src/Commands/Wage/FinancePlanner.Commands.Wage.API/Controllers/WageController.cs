using FinancePlanner.Common.Values;
using FinancePlanner.Commands.Common.Helpers;
using FinancePlanner.Commands.Wage.Domain.Contracts.Request;
using FinancePlanner.Commands.Wage.Domain.Handlers;
using FinancePlanner.Shared.Common.Result;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Common.Utilities.MoneyUtil;

namespace FinancePlanner.Common.Wage.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WageController : ControllerBase
{
    private readonly IWageService _wageService;

    public WageController(IWageService wageService)
    {
        _wageService = wageService;
    }

    [HttpPost(Name = "add")]
    public IActionResult AddWage(AddWageRequest addWageRequest)
    {
        _wageService.AddWage(addWageRequest);
        return new ContentResult
        {
            Content = "HI",
            ContentType = "text/plain",
            StatusCode = StatusCodes.Status200OK
        };


        // return ControllerHelper.Convert(ResultT<WageCalculationResponse>.Failure(Error.Validation(ErrorCode.InvalidSalaryFrequency,
            // ErrorDescription.InvalidSalaryFrequency)));
    }
}