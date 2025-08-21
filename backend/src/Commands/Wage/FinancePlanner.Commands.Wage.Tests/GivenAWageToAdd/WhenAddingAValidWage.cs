using FinancePlanner.Commands.Wage.Application;
using FinancePlanner.Commands.Wage.Domain.Contracts.Request;
using FinancePlanner.Commands.Wage.Domain.Handlers;
using FinancePlanner.Commands.Wage.Repository;

namespace FinancePlanner.Commands.Wage.Tests.GivenAWageToAdd;
using Moq;

public class WhenAddingAValidWage
{
    private AddWageRequest _result;
    private const int UserID = 1;
    private const int Amount = 123;
    private DateTime datePaid; 
    
    [SetUp]
    public void Setup()
    {
        datePaid = new DateTime(2025, 08, 21);
        
        var wageRepositoryMock = new Mock<IWageRepository>();
        
        wageRepositoryMock
            .Setup(x => x.AddWage(It.IsAny<AddWageRequest>()))
            .Callback((AddWageRequest req) => _result = req);
        
        IWageService wageService = new WageService(wageRepositoryMock.Object);

        var wageRequest = new AddWageRequest()
        {
            UserID = UserID,
            Value = Amount,
            DatePaid = datePaid
        };
        
        wageService.AddWage(wageRequest);
    }

    [Test]
    public void ThenCorrectWageIsAdded()
    {
        Assert.That(_result.UserID, Is.EqualTo(UserID));
        Assert.That(_result.Value, Is.EqualTo(Amount));
        Assert.That(_result.DatePaid, Is.EqualTo(datePaid));
    }
}