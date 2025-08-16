using FinancePlanner.Common.Models;
using FinancePlanner.Common.Values;
using FinancePlanner.Queries.Wage.Application;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using Microsoft.AspNetCore.Mvc;
using FinancePlanner.Queries.Wage.Domain.Handlers;

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
    public WageResponse CalculateWage(Public.WageCalculationRequest wageCalculationRequest)
    {
        var salaryFrequencySuccess= Enum.TryParse<SalaryFrequency>(wageCalculationRequest.SalaryFrequency, out var salaryFrequency);

        if (salaryFrequencySuccess)
        {
            return _wageService.CalculateWage(new WageCalculationRequest
            {
                Salary = wageCalculationRequest.Salary,
                SalaryFrequency = salaryFrequency,
                TaxFreeAmount = wageCalculationRequest.TaxFreeAmount
            });
        }

        return null;
    }
}