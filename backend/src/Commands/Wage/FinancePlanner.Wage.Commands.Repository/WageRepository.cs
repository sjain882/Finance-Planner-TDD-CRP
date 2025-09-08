using System.Data.Common;
using FinancePlanner.Wage.Commands.Domain.Contracts.Request;
using Npgsql;

namespace FinancePlanner.Wage.Commands.Repository;

public class WageRepository : IWageRepository
{
    private readonly IDatabaseQuery _databaseQuery;
    public const string connectionString = "User ID=root;Password=root;Host=postgres-master;Port=5432;DatabaseQuery=root;";
    
    public WageRepository(IDatabaseQuery databaseQuery)
    {
        _databaseQuery = databaseQuery;
    }
    
    public async Task AddWage(AddWageRequest addWageRequest)
    {
        var query = """
                    INSERT INTO Wage (datepaid, userid, value)
                    VALUES (@datepaid, @userid, @value);
                    """;

        var parameters = new List<DbParameter>()
        {
            // new NpgsqlParameter("@id", 1),
            new NpgsqlParameter("@datepaid", addWageRequest.DatePaid),
            new NpgsqlParameter("@userid", addWageRequest.UserID),
            new NpgsqlParameter("@value", addWageRequest.Value)
        };
        
        await _databaseQuery.UpdateTable(query, parameters);
    }

    public async Task RetrieveAll()
    {
        await using var dataSource = NpgsqlDataSource.Create(connectionString);

        // Retrieve all rows
        await using (var cmd = dataSource.CreateCommand("SELECT some_field FROM data"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                Console.WriteLine(reader.GetString(0));
            }
        }
    }
}