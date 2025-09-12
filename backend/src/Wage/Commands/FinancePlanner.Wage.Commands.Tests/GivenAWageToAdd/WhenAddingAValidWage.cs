using FinancePlanner.Wage.Commands.Application;
using FinancePlanner.Wage.Commands.Domain.Contracts.Request;
using FinancePlanner.Wage.Commands.Domain.Handlers;
using FinancePlanner.Wage.Commands.Repository;
using Moq;

namespace FinancePlanner.Wage.Commands.Tests.GivenAWageToAdd;

public class WhenAddingAValidWage
{
    private const int UserID = 1;
    private const int Amount = 123;
    private AddWageRequest _result;
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

        var wageRequest = new AddWageRequest
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