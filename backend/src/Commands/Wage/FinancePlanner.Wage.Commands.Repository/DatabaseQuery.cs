using System.Data;
using System.Data.Common;
using Npgsql;

namespace FinancePlanner.Wage.Commands.Repository;

public class DatabaseQuery : IDatabaseQuery
{
    private readonly string _connectionString;

    public DatabaseQuery(string connectionString)
    {
        _connectionString = connectionString;
        ;
    }

    public async Task UpdateTable(string query, List<DbParameter>? parameters = null)
    {
        await using var dataSource = NpgsqlDataSource.Create(_connectionString);

        await using (var cmd = dataSource.CreateCommand(query))
        {
            if (parameters is not null)
                foreach (var dbParameter in parameters)
                    cmd.Parameters.Add(dbParameter);

            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task<DataTable> GetTable(string query, List<DbParameter>? parameters = null)
    {
        await using var dataSource = NpgsqlDataSource.Create(_connectionString);

        await using (var cmd = dataSource.CreateCommand(query))
        {
            if (parameters is not null)
                foreach (var dbParameter in parameters)
                    cmd.Parameters.Add(dbParameter);

            var dataTable = new DataTable();
            dataTable.Load(await cmd.ExecuteReaderAsync());
            return dataTable;
        }
    }
}