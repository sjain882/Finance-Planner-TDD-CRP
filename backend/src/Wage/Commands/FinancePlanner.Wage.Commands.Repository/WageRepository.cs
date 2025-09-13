using System.Data.Common;
using FinancePlanner.Wage.Commands.Domain.Contracts.Request;
using Npgsql;

namespace FinancePlanner.Wage.Commands.Repository;

public class WageRepository : IWageRepository
{
    private readonly IDatabaseQuery _databaseQuery;

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

        var parameters = new List<DbParameter>
        {
            // new NpgsqlParameter("@id", 1),
            new NpgsqlParameter("@datepaid", addWageRequest.DatePaid),
            new NpgsqlParameter("@userid", addWageRequest.UserID),
            new NpgsqlParameter("@value", addWageRequest.Value)
        };

        await _databaseQuery.UpdateTable(query, parameters);
    }
}