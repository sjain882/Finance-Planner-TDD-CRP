using FinancePlanner.Commands.Wage.Domain.Contracts.Request;
using Npgsql;

namespace FinancePlanner.Commands.Wage.Repository;

public class WageRepository : IWageRepository
{
    public const string connectionString = "User ID=root;Password=root;Host=postgres-master;Port=5432;Database=root;";
    
    public WageRepository()
    {
        
    }
    
    public async Task AddWage(AddWageRequest addWageRequest)
    {
        await using var dataSource = NpgsqlDataSource.Create(connectionString);
        
        await using (var cmd = dataSource.CreateCommand(
                         """
                         INSERT INTO Wage (datepaid, userid, value)
                         VALUES (@datepaid, @userid, @value);
                         """))
        {
            // Assuming `id` is auto-generated normally, 
            // but if you must set it manually:
            cmd.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Integer, 1);

            cmd.Parameters.AddWithValue("@datepaid", NpgsqlTypes.NpgsqlDbType.Date, addWageRequest.DatePaid);
            cmd.Parameters.AddWithValue("@userid", NpgsqlTypes.NpgsqlDbType.Integer, addWageRequest.UserID);
            cmd.Parameters.AddWithValue("@value", NpgsqlTypes.NpgsqlDbType.Numeric, addWageRequest.Value);

            await cmd.ExecuteNonQueryAsync();
        }
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