using System.Data;
using FinancePlanner.Wage.Commands.DatabaseMigration;
using FinancePlanner.Wage.Commands.Domain.Contracts.Request;
using FinancePlanner.Wage.Commands.Repository;
using Testcontainers.PostgreSql;

namespace FinancePlanner.Wage.Commands.Tests.GivenAWageToStoreInDatabase;

public class WhenAddingAValidWage
{
    private const int UserID = 1;
    private const int Amount = 123;
    public PostgreSqlContainer _postgres;
    public DatabaseQuery databaseQuery;
    private DateTime datePaid;

    [OneTimeSetUp]
    public async Task SetUp()
    {
        datePaid = new DateTime(2025, 08, 21);

        _postgres = new PostgreSqlBuilder()
            .WithImage("postgres:16")
            .WithCleanUp(true)
            .Build();

        await _postgres.StartAsync();

        Migration.CheckMigration(_postgres.GetConnectionString());

        databaseQuery = new DatabaseQuery(_postgres.GetConnectionString());

        var wageRepository = new WageRepository(databaseQuery);

        var addWageRequest = new AddWageRequest
        {
            UserID = UserID,
            Value = Amount,
            DatePaid = datePaid
        };

        await wageRepository.AddWage(addWageRequest);
    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        if (_postgres != null) await _postgres.DisposeAsync();
    }

    [Test]
    public async Task ThenCorrectWageIsStoredInDatabase()
    {
        var query = """
                    SELECT datepaid, userid, value
                    FROM Wage;
                    """;

        var result = await databaseQuery.GetTable(query);

        var userIdResult = result.Rows[0].Field<int>("userid");
        Assert.That(userIdResult, Is.EqualTo(UserID));

        var datePaidResult = result.Rows[0].Field<DateTime>("datepaid");
        Assert.That(datePaidResult, Is.EqualTo(datePaid));

        var valueResult = result.Rows[0].Field<decimal>("value");
        Assert.That(valueResult, Is.EqualTo(Amount));
    }
}