using System.IO.Enumeration;
using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculator.Handlers;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Tests.GivenYearlySalary;

// Injects into setup instead of method for class wide test
[TestFixture(1, 1)]
[TestFixture(20000, 20000)]
public class WhenCalculatingFromAYearlyIncome
{
    private HandlerResult _actualSalary;
    private readonly decimal _inputSalary;
    private readonly decimal _expectedSalary;

    public WhenCalculatingFromAYearlyIncome(double inputSalary, double expectedSalary)
    {
        _inputSalary = (decimal)inputSalary;
        _expectedSalary = (decimal)expectedSalary;
    }

    [SetUp]
    public void Setup()
    {
        var sut = new FromYearlySalaryHandler();
        _actualSalary = sut.Handle(_inputSalary);
    }
    
    [Test]
    public void ThenTheCorrectYearlyIncomeIsCalculated()
    {
        Assert.That(_actualSalary.YearlySalary, Is.EqualTo(_expectedSalary));
    }
}


