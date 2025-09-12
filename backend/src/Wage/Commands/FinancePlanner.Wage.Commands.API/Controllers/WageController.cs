using FinancePlanner.Wage.Commands.Domain.Contracts.Request;
using FinancePlanner.Wage.Commands.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FinancePlanner.Wage.Commands.API.Controllers;

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