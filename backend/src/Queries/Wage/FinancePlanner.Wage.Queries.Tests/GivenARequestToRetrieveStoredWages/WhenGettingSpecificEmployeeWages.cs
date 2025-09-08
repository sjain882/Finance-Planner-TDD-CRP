using FinancePlanner.Common.Utilities.Result;
using FinancePlanner.Wage.Queries.DatabaseMigration;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;
using FinancePlanner.Wage.Queries.Repository;
using Npgsql;
using Testcontainers.PostgreSql;

namespace FinancePlanner.Wage.Queries.Tests.GivenARequestToRetrieveStoredWages;

public class WhenGettingSpecificEmployeeWages
{
    private const int UserID = 1;
    private const int Amount = 123;
    public DatabaseQuery _databaseQuery;
    public PostgreSqlContainer _postgres;
    private ResultT<List<DayWageResponse>> _wageListResult;
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

        await Setup_SeedDatabase();

        _databaseQuery = new DatabaseQuery(_postgres.GetConnectionString());

        var wageRepository = new WageRepository(_databaseQuery);

        _wageListResult = await wageRepository.GetEmployeeWage(1);
    }

    public async Task Setup_SeedDatabase()
    {
        var query = """
                    INSERT INTO Wage (datepaid, userid, value)
                    VALUES ('2011-01-26T00:00:00+00:00', 1, 20000),
                           ('2016-05-12T00:00:00+00:00', 2, 50000);
                    """;

        await using var dataSource = NpgsqlDataSource.Create(_postgres.GetConnectionString());

        await using (var cmd = dataSource.CreateCommand(query))
        {
            await cmd.ExecuteNonQueryAsync();
        }
    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        if (_postgres != null) await _postgres.DisposeAsync();
    }

    [Test]
    public void ThenThereAreNoErrors()
    {
        Assert.That(_wageListResult.IsSuccess, Is.EqualTo(true));
    }

    [Test]
    public void ThenOnlyCorrectUsersWagesAreRetrieved()
    {
        foreach (var x in _wageListResult.Value) Assert.That(x.UserID, Is.EqualTo(1));
    }

    public void ThenCorrectWagesAreRetrievedFromDatabase()
    {
        var wageResult1 = _wageListResult.Value[0];
        Assert.That(wageResult1.DatePaid, Is.EqualTo(DateTime.Parse("2011-01-26T00:00:00+00:00").ToUniversalTime()));

        Assert.That(wageResult1.UserID, Is.EqualTo(1));

        Assert.That(wageResult1.Value, Is.EqualTo(20000));
    }
}